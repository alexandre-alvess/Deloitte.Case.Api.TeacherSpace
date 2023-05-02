using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="BoletimServico"/>.
    /// </summary>
    public class BoletimServico : BaseServico<BoletimModel, Boletim, IBoletimRepositorio, BoletimValidador>, IBoletimServico
    {
        /// <summary>
        /// Define o repositório de aluno.
        /// </summary>
        private readonly IAlunoRepositorio _alunoRepositorio;

        /// <summary>
        /// Define o repositório de turma.
        /// </summary>
        private readonly ITurmaRepositorio _turmaRepositorio;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="BoletimServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio de boletim <see cref="IBoletimRepositorio"/>.</param>
        /// <param name="repositorio">O repositorio de aluno <see cref="IAlunoRepositorio"/>.</param>
        /// <param name="repositorio">O repositorio de turma <see cref="ITurmaRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        public BoletimServico(
            IBoletimRepositorio repositorio,
            IAlunoRepositorio alunoRepositorio,
            ITurmaRepositorio turmaRepositorio,
            IMapper mapper) : base(repositorio, mapper)
        {
            _alunoRepositorio = alunoRepositorio;
            _turmaRepositorio = turmaRepositorio;
        }

        /// <summary>
        /// Consulta a lista paginada de boletins por turma.
        /// </summary>
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Os boletins da turma consultada <see cref="TModel"/>.</returns>
        public async Task<TurmaBoletimModel> ConsultarListaPorTurma(Guid turmaId)
        {
            var turmaBoletinsResultado = new TurmaBoletimModel();

            var dbContext = _repositorio.DbContext;

            var turmaBoletins = await (from boletim in dbContext.Boletins
                                       join aluno in dbContext.Alunos on boletim.AlunoId equals aluno.Id
                                       join pessoaAluno in dbContext.Pessoas on aluno.PessoaId equals pessoaAluno.Id
                                       join turma in dbContext.Turmas on boletim.TurmaId equals turma.Id
                                       join disciplina in dbContext.Disciplinas on turma.DisciplinaId equals disciplina.Id
                                       join professor in dbContext.Professores on turma.ProfessorId equals professor.Id
                                       join pessoaProfessor in dbContext.Pessoas on professor.PessoaId equals pessoaProfessor.Id
                                       where boletim.TurmaId == turmaId && boletim.Ativo
                                       select new
                                       {
                                           BoletimId = boletim.Id,
                                           AlunoId = aluno.Id,
                                           Turma = turma.Nome,
                                           Disciplina = disciplina.Nome,
                                           Professor = pessoaProfessor.Nome,
                                           Aluno = pessoaAluno.Nome,
                                           Nota = boletim.Nota,
                                           DataEntrega = boletim.DataEntrega
                                       }).ToListAsync();

            if (turmaBoletins != null && turmaBoletins.Any())
            {
                var turmaBoletinsGroup = turmaBoletins.GroupBy(x => x.AlunoId);
                var turmaBoletimFirst = turmaBoletins.First();
                
                turmaBoletinsResultado.Turma = turmaBoletimFirst.Turma;
                turmaBoletinsResultado.Professor = turmaBoletimFirst.Professor;
                turmaBoletinsResultado.Disciplina = turmaBoletimFirst.Disciplina;
                turmaBoletinsResultado.AlunosBoletim = new List<AlunoBoletimModel>();

                foreach (var alunoBoletins in turmaBoletinsGroup)
                {
                    turmaBoletinsResultado.AlunosBoletim.Add(new AlunoBoletimModel
                    {
                        Aluno = alunoBoletins.First().Aluno,
                        AlunoId = alunoBoletins.First().AlunoId,
                        NotasBoletim = alunoBoletins.Select(x => new BoletimModel
                        {
                            Nota = x.Nota,
                            DataEntrega = x.DataEntrega
                        }).ToList()
                    });
                }
            }

            return turmaBoletinsResultado;
        }

        protected override async Task<DataResult<BoletimModel>> AntesDeAdicionar(BoletimModel model, Boletim entidade)
        {
            return await ValideAlunoTurma(model);
        }

        protected override async Task<DataResult<BoletimModel>> AntesDeAtualizar(BoletimModel model, Boletim entidade)
        {
            return await ValideAlunoTurma(model);
        }

        private async Task<DataResult<BoletimModel>> ValideAlunoTurma(BoletimModel model)
        {
            var turma = await _turmaRepositorio.Consultar(model.TurmaId);
            if (turma == null)
                return DataResult<BoletimModel>.Falha("Turma informada não existe.");

            var aluno = await _alunoRepositorio.Consultar(model.AlunoId);
            if (aluno == null)
                return DataResult<BoletimModel>.Falha("Aluno informado não existe.");

            var existeAlunoTurma = await _turmaRepositorio.ExisteAluno(model.AlunoId, model.TurmaId);
            if (!existeAlunoTurma)
                return DataResult<BoletimModel>.Falha("Não existe nenhum aluno para a turma informada.");

            return DataResult<BoletimModel>.Successo(model);
        }
    }
}
