using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using Deloitte.Case.TeacherSpace.Core.Enumeradores;
using Deloitte.Case.TeacherSpace.Core.Models;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define a classe <see cref="BaseCrudApiController"/>.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TService"></typeparam>
    [Route("v1/[controller]")]
    [ApiController]
    public abstract class BaseCrudApiController<TModel, TRequest, TService> : ControllerBase
        where TModel : BaseModel
        where TRequest : BaseRequest
        where TService : IBaseService<TModel>
    {
        /// <summary>
        /// Define o mapper.
        /// </summary>
        private readonly IMapper _mapper;

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

            return Ok(resultado);
        }

        protected ActionResult Error(string codigoErro, string mensagemErro, HttpStatusCode status, EnumApiErroTipo tipoErro = EnumApiErroTipo.Negocio)
        {
            return new ObjectResult(ApiErrorMessage.Erro(new ApiErroMessageItem(codigoErro, mensagemErro, tipoErro)))
            {
                StatusCode = (int)status
            };
        }

        protected virtual string FormateErrosModelState()
        {
            return string.Join(", ", ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));
        }
    }
}
