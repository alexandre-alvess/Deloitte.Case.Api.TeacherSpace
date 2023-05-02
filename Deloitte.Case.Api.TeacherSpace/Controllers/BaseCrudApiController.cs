using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define a classe <see cref="BaseCrudApiController"/>.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TService"></typeparam>
    public abstract class BaseCrudApiController<TModel, TRequest, TResponse, TService> : BaseApiController
        where TModel : BaseModel
        where TRequest : BaseRequest
        where TResponse : class
        where TService : IBaseServico<TModel>
    {
        /// <summary>
        /// Define o mapper.
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Define o serviço.
        /// </summary>
        protected readonly TService _servico;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="BaseCrudApiController"/>.
        /// </summary>
        /// <param name="servico">O serviço base do controlador <see cref="TService"/>.</param>
        /// <param name="mapper">O mapper <see cref="IMapper"/>.</param>
        protected BaseCrudApiController(TService servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        protected virtual async Task<IActionResult> AdicionarInterno([FromBody] TRequest request)
        {
            var model = _mapper.Map<TRequest, TModel>(request);

            var resultado = await _servico.Criar(model);
            if (!resultado.StatusOk)
                return Error("InternalServerError", string.Join(", ", resultado.Erros), HttpStatusCode.InternalServerError);

            return Ok(_mapper.Map<TModel, TResponse>(resultado.Dado));
        }

        protected virtual async Task<IActionResult> ConsultarInterno([FromQuery] Guid alunoId)
        {
            var model = await _servico.Consultar(alunoId);
            return Ok(_mapper.Map<TModel, TResponse>(model));
        }

        protected virtual async Task<IActionResult> InativarInterno([FromQuery] Guid alunoId)
        {
            var resultado = await _servico.Inativar(alunoId);
            if (!resultado.StatusOk)
                return Error("InternalServerError", string.Join(", ", resultado.Erros), HttpStatusCode.InternalServerError);

            return Ok(_mapper.Map<TModel, TResponse>(resultado.Dado));
        }

        protected virtual async Task<IActionResult> AtualizarInterno([FromBody] TRequest request)
        {
            var model = _mapper.Map<TRequest, TModel>(request);

            var resultado = await _servico.Atualizar(model);
            if (!resultado.StatusOk)
                return Error("InternalServerError", string.Join(", ", resultado.Erros), HttpStatusCode.InternalServerError);

            return Ok(_mapper.Map<TModel, TResponse>(resultado.Dado));
        }

        protected virtual async Task<IActionResult> ConsultarListaInterno([FromQuery] ApiParametros parametros)
        {
            var resultado = await _servico.ConsultarLista(parametros.Pagina, parametros.Quantidade);
            return Ok(_mapper.Map<IEnumerable<TModel>, IEnumerable<TResponse>>(resultado));
        }
    }
}
