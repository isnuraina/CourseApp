using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.Account;
using Service.Helpers.Enums;
using Service.Helpers.Responses;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task CreateRolesAsync()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name=role.ToString()});
                }
            }
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
           var result= await _userManager.CreateAsync(user, model.UserPassword);
            if (!result.Succeeded)
            {
                return new RegisterResponse { Success = false, Errors = result.Errors.Select(m=>m.Description).ToArray() };
            }
            await _userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
            return new RegisterResponse { Success = true, Errors = null };
        }
    }
}
