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
    /// Define o controller <see cref="DisciplinaController"/>.
    /// </summary>
    [Authorize("Bearer")]
    public class DisciplinaController : BaseCrudApiController<DisciplinaModel, DisciplinaRequest, DisciplinaResponse, IDisciplinaServico>
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="AlunoController"/>.
        /// </summary>
        /// <param name="disciplinaServico">O serviço de disciplina  <see cref="IDisciplinaServico"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        public DisciplinaController(IDisciplinaServico disciplinaServico, IMapper mapper) : base(disciplinaServico, mapper)
        {
        }

        /// <summary>
        /// ADICIONAR.
        /// </summary>
        /// <param name="request">O request de disciplina <see cref="DisciplinaRequest"/>.</param>
        /// <returns>Os dados da disciplina registrada.</returns>
        [HttpPost("Adicionar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AlunoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([Required, FromBody] DisciplinaRequest request)
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
        /// <param name="request">O request de disciplina <see cref="DisciplinaRequest"/>.</param>
        /// <returns>Os dados da disciplina registrada.</returns>
        [HttpPut("Atualizar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(DisciplinaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([Required, FromBody] DisciplinaRequest request)
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
        /// <param name="disciplinaId">O identificador da disciplina <see cref="Guid"/>.</param>
        /// <returns>Os dados da disciplina consultada.</returns>
        [HttpGet("Consultar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(DisciplinaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Consultar([Required, FromQuery] Guid disciplinaId)
        {
            return await ConsultarInterno(disciplinaId);
        }

        /// <summary>
        /// CONSULTAR LISTA.
        /// </summary>
        /// <param name="parametros">Os parâmetros para realizar a consulta <see cref="ApiParametros"/>.</param>
        /// <returns>Os dados das disciplinas consultadas.</returns>
        [HttpGet("ConsultarLista")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DisciplinaResponse>), StatusCodes.Status200OK)]
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
        /// <param name="disciplinaId">O identificador da disciplina <see cref="Guid"/>.</param>
        /// <returns>Os dados da disciplina inativada.</returns>
        [HttpDelete("Inativar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(DisciplinaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inativar([Required, FromQuery] Guid disciplinaId)
        {
            return await InativarInterno(disciplinaId);
        }
    }
}
