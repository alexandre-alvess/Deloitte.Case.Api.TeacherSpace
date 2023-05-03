using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios.Enumeradores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="UsuarioRepositorio"/>.
    /// </summary>
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        /// <summary>
        /// Define o repositorio de Pessoa.
        /// </summary>
        private readonly IPessoaRepositorio _pessoaRepositorio;

        /// <summary>
        /// Define o repositorio de Professor.
        /// </summary>
        private readonly IProfessorRepositorio _professorRepositorio;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="UsuarioRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        /// <param name="pessoaRepositorio">O repositório de pessoa <see cref="IPessoaRepositorio"/>.</param>
        /// <param name="professorRepositorio">O repositório de professor <see cref="IProfessorRepositorio"/>.</param>
        public UsuarioRepositorio(
            TeacherSpaceContext context,
            IPessoaRepositorio pessoaRepositorio,
            IProfessorRepositorio professorRepositorio) : base(context, i => i.Include(a => a.Pessoa))
        {
            _professorRepositorio = professorRepositorio;
        }

        /// <summary>
        /// Adiciona a entidade na base de dados.
        /// </summary>
        /// <param name="obj">O usuário <see cref="Usuario"/>.</param>
        /// <returns>A entidade adicionada <see cref="Usuario"/>.</returns>
        public override async Task<DataResult<Usuario>> Criar(Usuario obj)
        {
            if (obj.TipoPerfil == EnumTipoPerfilUsuario.Professor)
            {
                var resultadoProfessor = await _professorRepositorio.Criar(new Professor
                {
                    Pessoa = obj.Pessoa
                });
                
                if (!resultadoProfessor.StatusOk)
                    return DataResult<Usuario>.Falha(resultadoProfessor.Erros);
            }
            else
            {
                var resultado = await _pessoaRepositorio.Criar(obj.Pessoa);
                if (!resultado.StatusOk)
                    return DataResult<Usuario>.Falha(resultado.Erros);
            }

            obj.PessoaId = obj.Pessoa.Id;

            return await base.Criar(obj);
        }
    }
}
