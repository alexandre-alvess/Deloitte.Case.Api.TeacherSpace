﻿using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Requests;
using Deloitte.Case.Api.TeacherSpace.Models.Responses;
using Deloitte.Case.TeacherSpace.Core.Models;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define o controller <see cref="AlunoController"/>.
    /// </summary>
    public class AlunoController : BaseCrudApiController<AlunoModel, AlunoRequest, AlunoResponse, IAlunoServico>
    {
        /// <summary>
        /// Define o mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="AlunoController"/>.
        /// </summary>
        /// <param name="alunoServico">O serviço de aluno  <see cref="IAlunoServico"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        public AlunoController(IAlunoServico alunoServico, IMapper mapper) : base(alunoServico, mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// ADICIONAR.
        /// </summary>
        /// <param name="request">O request de aluno <see cref="AlunoRequest"/>.</param>
        /// <returns>Os dados do aluno registrado.</returns>
        [HttpPost("Adicionar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AlunoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([Required, FromBody] AlunoRequest request)
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
        /// <param name="request">O request de aluno <see cref="AlunoRequest"/>.</param>
        /// <returns>Os dados do aluno registrado.</returns>
        [HttpPut("Atualizar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AlunoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar([Required, FromBody] AlunoRequest request)
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
        /// <param name="alunoId">O identificador do aluno <see cref="Guid"/>.</param>
        /// <returns>Os dados do aluno consultado.</returns>
        [HttpGet("Consultar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AlunoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Consultar([Required, FromQuery] Guid alunoId)
        {
            return await ConsultarInterno(alunoId);
        }

        /// <summary>
        /// CONSULTAR LISTA.
        /// </summary>
        /// <param name="alunoId">O identificador do aluno <see cref="Guid"/>.</param>
        /// <returns>Os dados do aluno consultados.</returns>
        [HttpGet("ConsultarLista")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<AlunoResponse>), StatusCodes.Status200OK)]
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
        /// <param name="alunoId">O identificador do aluno <see cref="Guid"/>.</param>
        /// <returns>Os dados do aluno inativado.</returns>
        [HttpDelete("Inativar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AlunoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inativar([Required, FromQuery] Guid alunoId)
        {
            return await InativarInterno(alunoId);
        }
    }
}
