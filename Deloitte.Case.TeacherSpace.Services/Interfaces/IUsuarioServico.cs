using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Services.Models;

namespace Deloitte.Case.TeacherSpace.Services.Interfaces
{
    /// <summary>
    /// Define a interface <see cref="IUsuarioServico"/>.
    /// </summary>
    public interface IUsuarioServico : IBaseServico<UsuarioModel>
    {
        /// <summary>
        /// Valida as crendeciais de autenticação do usuário.
        /// </summary>
        /// <param name="autenticacaoModel">Os dados de autenticação do usuário.</param>
        /// <returns>A validade das credenciais do usuário <see cref="DataResult{bool}"/>.</returns>
        Task<DataResult<bool>> ValideCredenciais(AutenticacaoModel autenticacaoModel);

        /// <summary>
        /// Autentica o usuário gerando o token com os dados do usuário.
        /// </summary>
        /// <param name="autenticacaoModel">Os dados de autenticação do usuário.</param>
        /// <returns>Os dados de autenticação do usuário <see cref="DataResult{UsuarioAutenticacao}"/>.</returns>
        Task<DataResult<UsuarioAutenticacao>> Autenticar(AutenticacaoModel autenticacaoModel);
    }
}
