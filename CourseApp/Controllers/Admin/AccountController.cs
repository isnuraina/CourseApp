using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

namespace CourseApp.Controllers.Admin
{
    public class AccountController:BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoles()
        {
            await _accountService.CreateRolesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            return Ok(await _accountService.GetAllUsersWithRolesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto request)
        {
            return Ok(await _accountService.LoginAsync(request));
        }
    }
}
