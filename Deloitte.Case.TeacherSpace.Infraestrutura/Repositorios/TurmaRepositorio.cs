using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="TurmaRepositorio"/>.
    /// </summary>
    public class TurmaRepositorio : BaseRepositorio<Turma>, ITurmaRepositorio
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="TurmaRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        public TurmaRepositorio(TeacherSpaceContext context) : base(context, i => i.Include(t => t.Professor)
                                                                                   .ThenInclude(p => p.Pessoa)
                                                                                   .Include(t => t.Disciplina)
                                                                                   .Include(t => t.Alunos)
                                                                                   .ThenInclude(p => p.Pessoa))
        {
        }

        /// <summary>
        /// Adicina o aluno na turma.
        /// </summary>
        /// <param name="obj">A entidade aluno turma.</param>
        /// <returns>O aluno adicionado na turma <see cref="AlunoTurma"/>.</returns>
        public async Task<DataResult<AlunoTurma>> AdicionarAluno(AlunoTurma obj)
        {
            _context.Add(obj);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? DataResult<AlunoTurma>.Successo(obj) : DataResult<AlunoTurma>.Falha("Falha ao tentar adicionar entidade.");
        }

        /// <summary>
        /// Verifica se o aluno está registrado na turma.
        /// </summary>
        /// <param name="alunoId">O identificador de aluno <see cref="Guid"/>.</param>
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Se o aluno está registrado na turma <see cref="bool"/>.</returns>
        public async Task<bool> ExisteAluno(Guid alunoId, Guid turmaId)
        {
            return await _context.AlunoTurmas.AsNoTracking().AnyAsync(x => x.AlunoId == alunoId && x.TurmaId == turmaId && x.Ativo);
        }

        /// <summary>
        /// Atualiza o aluno na turma.
        /// </summary>
        /// <param name="obj">A entidade aluno turma.</param>
        /// <returns>O aluno atualizado na turma <see cref="AlunoTurma"/>.</returns>
        public async Task<DataResult<AlunoTurma>> AtualizarAluno(AlunoTurma obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? DataResult<AlunoTurma>.Successo(obj) : DataResult<AlunoTurma>.Falha("Falha ao tentar atualizar entidade.");
        }
    }
}
