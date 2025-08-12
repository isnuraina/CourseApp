using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers.Client
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
} 
