using Microsoft.AspNetCore.Authorization;

namespace Deloitte.Case.Api.TeacherSpace.Controllers
{
    /// <summary>
    /// Define o controller <see cref="TurmaController"/>.
    /// </summary>
    [Authorize]
    public class TurmaController //: BaseCrudApiController
    {
    }
}
