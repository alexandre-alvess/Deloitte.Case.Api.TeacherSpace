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
    /// Define o controller <see cref="ProfessorController"/>.
    /// </summary>
    [Authorize("Bearer")]
    public class ProfessorController : BaseCrudApiController<ProfessorModel, ProfessorRequest, ProfessorResponse, IProfessorServico>
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfessorController"/>.
        /// </summary>
        /// <param name="professorService">O serviço de professor  <see cref="IProfessorServico"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        public ProfessorController(IProfessorServico professorService, IMapper mapper) : base(professorService, mapper)
        {
        }

        /// <summary>
        /// ADICIONAR.
        /// </summary>
        /// <param name="request">O request de professor <see cref="ProfessorRequest"/>.</param>
        /// <returns>Os dados do professor registrado.</returns>
        [HttpPost("Adicionar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ProfessorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([Required, FromBody] ProfessorRequest request)
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
        /// <param name="request">O request de professor <see cref="ProfessorRequest"/>.</param>
        /// <returns>Os dados do professor registrado.</returns>
        [HttpPut("Atualizar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ProfessorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([Required, FromBody] ProfessorRequest request)
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
        /// <param name="professorId">O identificador do professor <see cref="Guid"/>.</param>
        /// <returns>Os dados do professor consultado.</returns>
        [HttpGet("Consultar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ProfessorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Consultar([Required, FromQuery] Guid professorId)
        {
            return await ConsultarInterno(professorId);
        }

        /// <summary>
        /// CONSULTAR LISTA.
        /// </summary>
        /// <param name="parametros">Os parâmetros para realizar a consulta <see cref="ApiParametros"/>.</param>
        /// <returns>Os dados dos professores consultados.</returns>
        [HttpGet("ConsultarLista")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ProfessorResponse>), StatusCodes.Status200OK)]
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
        /// <param name="professorId">O identificador do professor <see cref="Guid"/>.</param>
        /// <returns>Os dados do professor inativado.</returns>
        [HttpDelete("Inativar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ProfessorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inativar([Required, FromQuery] Guid professorId)
        {
            return await InativarInterno(professorId);
        }
    }
}
