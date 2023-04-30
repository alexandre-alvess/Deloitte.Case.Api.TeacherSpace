using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="ProfessorRepositorio"/>.
    /// </summary>
    public class ProfessorRepositorio : BaseRepositorio<Professor>, IProfessorRepositorio
    {
        /// <summary>
        /// Define o repositorio de Pessoa.
        /// </summary>
        private readonly IPessoaRepositorio _pessoaRepositorio;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfessorRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        /// <param name="pessoaRepositorio">O repositório de Pessoa <see cref="IPessoaRepositorio"/>.</param>
        public ProfessorRepositorio(TeacherSpaceContext context, IPessoaRepositorio pessoaRepositorio) : base(context, i => i.Include(a => a.Pessoa))
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        /// <summary>
        /// Adiciona a entidae na base de dados.
        /// </summary>
        /// <param name="obj">O Professor <see cref="Professor"/>.</param>
        /// <returns>A entidade adicionada <see cref="Professor"/>.</returns>
        public override async Task<DataResult<Professor>> Criar(Professor obj)
        {
            var resultado = await _pessoaRepositorio.Criar(obj.Pessoa);
            if (!resultado.StatusOk)
                return DataResult<Professor>.Falha(resultado.Erros);

            obj.PessoaId = obj.Pessoa.Id;

            return await base.Criar(obj);
        }

        /// <summary>
        /// Atualiza a entidade na base de dados.
        /// </summary>
        /// <param name="obj">O Professor <see cref="Professor"/>.</param>
        /// <returns>A entidade atualizada <see cref="Professor"/>.</returns>
        public override async Task<DataResult<Professor>> Atualizar(Professor obj)
        {
            var resultadoPessoa = await _pessoaRepositorio.Atualizar(obj.Pessoa);
            if (!resultadoPessoa.StatusOk)
                return DataResult<Professor>.Falha(resultadoPessoa.Erros);

            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? DataResult<Professor>.Successo(obj) : DataResult<Professor>.Falha("Falha ao tentar atualizar entidade.");
        }
    }
}
