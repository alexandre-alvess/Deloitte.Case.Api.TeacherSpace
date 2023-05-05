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
    /// Define o controller <see cref="BoletimController"/>.
    /// </summary>
    [Authorize("Bearer")]
    public class BoletimController : BaseCrudApiController<BoletimModel, BoletimRequest, BoletimResponse, IBoletimServico>
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="BoletimController"/>.
        /// </summary>
        /// <param name="boletimServico">O serviço de boletim  <see cref="IBoletimServico"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        public BoletimController(IBoletimServico boletimServico, IMapper mapper) : base(boletimServico, mapper)
        {
        }

        /// <summary>
        /// ADICIONAR.
        /// </summary>
        /// <param name="request">O request de boletim <see cref="BoletimRequest"/>.</param>
        /// <returns>Os dados do boletim registrado.</returns>
        [HttpPost("Adicionar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(BoletimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([Required, FromBody] BoletimRequest request)
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
        /// <param name="request">O request de boletim <see cref="BoletimRequest"/>.</param>
        /// <returns>Os dados do boletim registrado.</returns>
        [HttpPut("Atualizar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(BoletimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([Required, FromBody] BoletimRequest request)
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
        /// <param name="boletimId">O identificador do boletim <see cref="Guid"/>.</param>
        /// <returns>Os dados do boletim consultado.</returns>
        [HttpGet("Consultar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(BoletimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Consultar([Required, FromQuery] Guid boletimId)
        {
            return await ConsultarInterno(boletimId);
        }

        /// <summary>
        /// CONSULTAR LISTA.
        /// </summary>
        /// <param name="parametros">Os parâmetros para realizar a consulta <see cref="ApiParametros"/>.</param>
        /// <returns>Os dados dos boletins consultados.</returns>
        [HttpGet("ConsultarLista")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PagedResult<BoletimResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarLista([Required, FromQuery] ApiParametros parametros)
        {
            return await ConsultarListaInterno(parametros);
        }

        /// <summary>
        /// CONSULTAR LISTA POR TURMA.
        /// </summary>
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Os boletins da turma.</returns>
        [HttpGet("ConsultarListaPorTurma")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TurmaBoletimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarListaPorTurma([Required, FromQuery] Guid turmaId)
        {
            var listaResultado = await _servico.ConsultarListaPorTurma(turmaId);
            return Ok(_mapper.Map<TurmaBoletimModel, TurmaBoletimResponse>(listaResultado));
        }

        /// <summary>
        /// INATIVAR.
        /// </summary>
        /// <param name="boletimId">O identificador do boletim <see cref="Guid"/>.</param>
        /// <returns>Os dados do boletim inativado.</returns>
        [HttpDelete("Inativar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(BoletimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inativar([Required, FromQuery] Guid boletimId)
        {
            return await InativarInterno(boletimId);
        }
    }
}
