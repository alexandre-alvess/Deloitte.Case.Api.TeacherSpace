using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Requests;
using Deloitte.Case.Api.TeacherSpace.Models.Responses;
using Deloitte.Case.TeacherSpace.Core.Models;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define o controller <see cref="UsuarioController"/>.
    /// </summary>
    [Authorize("Bearer")]
    public class UsuarioController : BaseCrudApiController<UsuarioModel, UsuarioRequest, UsuarioResponse, IUsuarioServico>
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="UsuarioController"/>.
        /// </summary>
        /// <param name="usuarioServico">O serviço de usuário  <see cref="IUsuarioServico"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        public UsuarioController(IUsuarioServico usuarioServico, IMapper mapper) : base(usuarioServico, mapper)
        {
        }

        /// <summary>
        /// ADICIONAR.
        /// </summary>
        /// <param name="request">O request de usuário <see cref="UsuarioRequest"/>.</param>
        /// <returns>Os dados do usuário registrado.</returns>
        [HttpPost("Adicionar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([Required, FromBody] UsuarioRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Error("BadRequest", FormateErrosModelState(), HttpStatusCode.BadRequest);
            }

            return await AdicionarInterno(request);
        }

        /// <summary>
        /// ATUALIZAR.
        /// </summary>
        /// <param name="request">O request de usuário <see cref="UsuarioRequest"/>.</param>
        /// <returns>Os dados do usuário registrado.</returns>
        [HttpPut("Atualizar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([Required, FromBody] UsuarioRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Error("BadRequest", FormateErrosModelState(), HttpStatusCode.BadRequest);
            }

            return await AtualizarInterno(request);
        }

        /// <summary>
        /// CONSULTAR.
        /// </summary>
        /// <param name="usuarioId">O identificador do usuário <see cref="Guid"/>.</param>
        /// <returns>Os dados do usuário consultado.</returns>
        [HttpGet("Consultar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Consultar([Required, FromQuery] Guid usuarioId)
        {
            return await ConsultarInterno(usuarioId);
        }

        /// <summary>
        /// CONSULTAR LISTA.
        /// </summary>
        /// <param name="parametros">Os parâmetros para realizar a consulta <see cref="ApiParametros"/>.</param>
        /// <returns>Os dados dos usuários consultados.</returns>
        [HttpGet("ConsultarLista")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PagedResult<UsuarioResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarLista([Required, FromQuery] ApiParametros parametros)
        {
            return await ConsultarListaInterno(parametros);
        }

        /// <summary>
        /// INATIVAR.
        /// </summary>
        /// <param name="usuarioId">O identificador do usuário <see cref="Guid"/>.</param>
        /// <returns>Os dados do usuário inativado.</returns>
        [HttpDelete("Inativar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inativar([Required, FromQuery] Guid usuarioId)
        {
            return await InativarInterno(usuarioId);
        }
    }
}
