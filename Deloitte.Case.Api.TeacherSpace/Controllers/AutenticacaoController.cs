using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Requests;
using Deloitte.Case.Api.TeacherSpace.Models.Responses;
using Deloitte.Case.TeacherSpace.Core.Models;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define a classe <see cref="AutenticacaoController"/>.
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    public class AutenticacaoController : BaseApiController
    {
        /// <summary>
        /// Define o serviço de usuário.
        /// </summary>
        private readonly IUsuarioServico _usuarioServico;

        /// <summary>
        /// Define o mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="AutenticacaoController"/>.
        /// </summary>
        /// <param name="usuarioServico">O serviço de usuário <see cref="IUsuarioServico"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        public AutenticacaoController(IUsuarioServico usuarioServico, IMapper mapper)
        {
            _usuarioServico = usuarioServico;
            _mapper = mapper;
        }

        /// <summary>
        /// AUTENTICAR USUARIO.
        /// </summary>
        /// <param name="request">A request de autenticação <see cref="AutenticacaoRequest"/>.</param>
        /// <returns>Os dados de autenticação <see cref="AutenticacaoResponse"/>.</returns>
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AutenticacaoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Autenticar([FromBody] AutenticacaoRequest request)
        {
            if (!ModelState.IsValid)
                return Error("BadRequest", FormateErrosModelState(), HttpStatusCode.BadRequest);

            var autenticacaoModel = _mapper.Map<AutenticacaoRequest, AutenticacaoModel>(request);
            var validadeCredencial = await _usuarioServico.ValideCredenciais(autenticacaoModel);

            if (!validadeCredencial.StatusOk)
                return Error("Unauthorized", string.Join(", ", validadeCredencial.Erros), HttpStatusCode.Unauthorized);

            var tokenResultado = await _usuarioServico.GereToken(autenticacaoModel);
            if (!tokenResultado.StatusOk)
                return Error("InternalServerError", string.Join(", ", tokenResultado.Erros), HttpStatusCode.InternalServerError);

            return Ok(new AutenticacaoResponse
            {
                Token = tokenResultado.Dado
            });
        }
    }
}
