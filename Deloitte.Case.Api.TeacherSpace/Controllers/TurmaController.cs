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
    /// Define o controller <see cref="TurmaController"/>.
    /// </summary>
    [Authorize("Bearer")]
    public class TurmaController : BaseCrudApiController<TurmaModel, TurmaRequest, TurmaResponse, ITurmaServico>
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="TurmaController"/>.
        /// </summary>
        /// <param name="turmaServico">O serviço de turma <see cref="ITurmaServico"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        public TurmaController(ITurmaServico turmaServico, IMapper mapper) : base(turmaServico, mapper)
        {
        }

        /// <summary>
        /// ADICIONAR.
        /// </summary>
        /// <param name="request">O request de turma <see cref="TurmaRequest"/>.</param>
        /// <returns>Os dados da turma registrada.</returns>
        [HttpPost("Adicionar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([Required, FromBody] TurmaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Error("BadRequest", FormateErrosModelState(), HttpStatusCode.BadRequest);
            }

            return await AdicionarInterno(request);
        }

        /// <summary>
        /// ADICIONAR ALUNO.
        /// </summary>
        /// <param name="request">O request do aluno para ser registrado na turma <see cref="AlunoTurmaRequest"/>.</param>
        /// <returns>Os dados do aluno registrado na turma.</returns>
        [HttpPost("AdicionarAluno")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AlunoTurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarAluno([Required, FromBody] AlunoTurmaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Error("BadRequest", FormateErrosModelState(), HttpStatusCode.BadRequest);
            }

            var model = _mapper.Map<AlunoTurmaRequest, AlunoTurmaModel>(request);
            var alunoTurmaResultado = await _servico.AdicionarAluno(model);

            if (!alunoTurmaResultado.StatusOk)
                return Error("InternalServerError", string.Join(", ", alunoTurmaResultado.Erros), HttpStatusCode.InternalServerError);

            return Ok(_mapper.Map<AlunoTurmaModel, AlunoTurmaResponse>(alunoTurmaResultado.Dado));
        }

        /// <summary>
        /// ATUALIZAR.
        /// </summary>
        /// <param name="request">O request de turma <see cref="TurmaRequest"/>.</param>
        /// <returns>Os dados da turma atualizada.</returns>
        [HttpPut("Atualizar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([Required, FromBody] TurmaRequest request)
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
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Os dados da turma consultada.</returns>
        [HttpGet("Consultar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Consultar([Required, FromQuery] Guid turmaId)
        {
            return await ConsultarInterno(turmaId);
        }

        /// <summary>
        /// CONSULTAR POR PROFESSOR.
        /// </summary>
        /// <param name="professorId">O identificador do professor <see cref="Guid"/>.</param>
        /// <param name="parametros">Os parâmetros para realizar a consulta <see cref="ApiParametros"/>.</param>
        /// <returns>Os dados da turma consultada.</returns>
        [HttpGet("ConsultarPorProfessor")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarPorProfessor([Required, FromQuery] Guid professorId, [Required, FromQuery] ApiParametros parametros)
        {
            var resultado = await _servico.ConsultarPorProfessor(professorId, parametros.Pagina, parametros.Quantidade);
            return Ok(_mapper.Map<IEnumerable<TurmaModel>, IEnumerable<TurmaResponse>>(resultado));
        }

        /// <summary>
        /// CONSULTAR LISTA.
        /// </summary>
        /// <param name="parametros">Os parâmetros para realizar a consulta <see cref="ApiParametros"/>.</param>
        /// <returns>Os dados das turmas consultadas.</returns>
        [HttpGet("ConsultarLista")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<TurmaResponse>), StatusCodes.Status200OK)]
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
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Os dados da turma inativada.</returns>
        [HttpDelete("Inativar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inativar([Required, FromQuery] Guid turmaId)
        {
            return await InativarInterno(turmaId);
        }

        /// <summary>
        /// INATIVAR ALUNO.
        /// </summary>
        /// <param name="request">O request do aluno para ser inativado na turma <see cref="AlunoTurmaRequest"/>.</param>
        /// <returns>Os dados do aluno inativado na turma.</returns>
        [HttpDelete("InativarAluno")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AlunoTurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InativarAluno([Required, FromBody] AlunoTurmaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Error("BadRequest", FormateErrosModelState(), HttpStatusCode.BadRequest);
            }

            var model = _mapper.Map<AlunoTurmaRequest, AlunoTurmaModel>(request);
            var alunoTurmaResultado = await _servico.InativarAluno(model);

            if (!alunoTurmaResultado.StatusOk)
                return Error("InternalServerError", string.Join(", ", alunoTurmaResultado.Erros), HttpStatusCode.InternalServerError);

            return Ok(_mapper.Map<AlunoTurmaModel, AlunoTurmaResponse>(alunoTurmaResultado.Dado));
        }
    }
}
