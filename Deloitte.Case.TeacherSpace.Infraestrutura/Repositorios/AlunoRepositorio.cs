using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="AlunoRepositorio"/>.
    /// </summary>
    public class AlunoRepositorio : BaseRepositorio<Aluno>, IAlunoRepositorio
    {
        /// <summary>
        /// Define o repositorio de Pessoa.
        /// </summary>
        private readonly IPessoaRepositorio _pessoaRepositorio;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="AlunoRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        /// <param name="pessoaRepositorio">O repositório de Pessoa <see cref="IPessoaRepositorio"/>.</param>
        public AlunoRepositorio(TeacherSpaceContext context, IPessoaRepositorio pessoaRepositorio) : base(context, i => i.Include(a => a.Pessoa))
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        /// <summary>
        /// Adiciona a entidae na base de dados.
        /// </summary>
        /// <param name="obj">O aluno <see cref="Aluno"/>.</param>
        /// <returns>A entidade adicionada <see cref="Aluno"/>.</returns>
        public override async Task<DataResult<Aluno>> Criar(Aluno obj)
        {
            var resultado = await _pessoaRepositorio.Criar(obj.Pessoa);
            if (!resultado.StatusOk)
                return DataResult<Aluno>.Falha(resultado.Erros);

            obj.PessoaId = obj.Pessoa.Id;

            return await base.Criar(obj);
        }

        /// <summary>
        /// Atualiza a entidade na base de dados.
        /// </summary>
        /// <param name="obj">O aluno <see cref="Aluno"/>.</param>
        /// <returns>A entidade atualizada <see cref="Aluno"/>.</returns>
        public override async Task<DataResult<Aluno>> Atualizar(Aluno obj)
        {
            var resultadoPessoa = await _pessoaRepositorio.Atualizar(obj.Pessoa);
            if (!resultadoPessoa.StatusOk)
                return DataResult<Aluno>.Falha(resultadoPessoa.Erros);

            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? DataResult<Aluno>.Successo(obj) : DataResult<Aluno>.Falha("Falha ao tentar atualizar entidade.");
        }
    }
}
