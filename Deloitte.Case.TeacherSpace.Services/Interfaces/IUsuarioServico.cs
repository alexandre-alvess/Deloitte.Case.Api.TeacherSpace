using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Services.Model;
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
        /// Gera o token com os dados de autenticação do usuário.
        /// </summary>
        /// <param name="autenticacaoModel">Os dados de autenticação do usuário.</param>
        /// <returns>O token de autenticação <see cref="DataResult{string}"/>.</returns>
        Task<DataResult<string>> GereToken(AutenticacaoModel autenticacaoModel);
    }
}
