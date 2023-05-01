using AutoMapper;
using Deloitte.Case.TeacherSpace.Core;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios.Enumeradores;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="UsuarioServico"/>.
    /// </summary>
    public class UsuarioServico : BaseServico<UsuarioModel, Usuario, IUsuarioRepositorio, UsuarioValidador>, IUsuarioServico
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="UsuarioServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio de usuário <see cref="IUsuarioRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        public UsuarioServico(IUsuarioRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        protected override void AntesDeAdicionar(UsuarioModel model, Usuario entidade)
        {
            entidade.Pessoa = _mapper.Map<Usuario, Pessoa>(entidade);
            entidade.Pessoa.Id = Guid.NewGuid();
            entidade.TipoPerfil = EnumTipoPerfilUsuario.Professor;
            entidade.Pessoa.Nome = model.Nome;
            entidade.Senha = Criptografia.Encrypt(entidade.Senha);
        }

        protected override void AntesDeAtualizar(UsuarioModel model, Usuario entidade)
        {
            entidade.Senha = Criptografia.Encrypt(entidade.Senha);
        }
    }
}
