using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
