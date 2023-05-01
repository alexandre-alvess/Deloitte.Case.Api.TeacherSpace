using Deloitte.Case.TeacherSpace.Core.Enumeradores;
using Deloitte.Case.TeacherSpace.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define a classe <see cref="BaseApiController"/>.
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
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
