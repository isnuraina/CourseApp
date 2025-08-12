using CourseApp.Controllers.Admin;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

namespace CourseApp.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
         
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto request)
        {
            var response = await _accountService.RegisterAsync(request);
            return Ok(response);
        }
    }
}
