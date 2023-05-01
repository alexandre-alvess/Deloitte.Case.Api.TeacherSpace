using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define o controller <see cref="BoletimController"/>.
    /// </summary>
    [Authorize]
    public class BoletimController //: BaseCrudApiController
    {
    }
}
