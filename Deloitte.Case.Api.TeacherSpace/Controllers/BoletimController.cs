using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define o controller <see cref="BoletimController"/>.
    /// </summary>
    [Authorize("Bearer")]
    public class BoletimController //: BaseCrudApiController
    {
    }
}
