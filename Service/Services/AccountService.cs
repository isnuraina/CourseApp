using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.DTOs.Account;
using Service.Helpers.Enums;
using Service.Helpers.Responses;
using Service.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<IEnumerable<UserRolesDto>> GetAllUsersWithRolesAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserRolesDto> usersWithRoles = new();
            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);
                usersWithRoles.Add(new UserRolesDto
                {
                    FullName = item.FullName,
                    UserName = item.UserName,
                    Email = item.Email,
                    Roles = roles.ToArray()
                });
            }
            return usersWithRoles;
        }

        public async Task<LoginResponse> LoginAsync(LoginDto model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            }
            if (user is null)
            {
                return new LoginResponse { Success = false, Error = "Login failed",Token=null };
            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return new LoginResponse { Success = false, Error = "Login failed", Token = null };
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            string token = GenerateJwtToken(user.UserName, userRoles.ToList());
            return new LoginResponse { Success = true, Error = null };
        }


        private string GenerateJwtToken(string username,List<string>roles)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("saa"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "https://localhost:7046/",
                audience: "https://localhost:7046/",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<RegisterResponse> RegisterAsync(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
           var result= await _userManager.CreateAsync(user, model.UserPassword);
            if (!result.Succeeded)
            {
                return new RegisterResponse { Success = false, Errors = result.Errors.Select(m=>m.Description).ToArray() };
            }
            await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
            return new RegisterResponse { Success = true, Errors = null };
        }
    }
}
