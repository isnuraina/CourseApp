using Service.DTOs.Account;
using Service.Helpers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> RegisterAsync(RegisterDto model);
        Task CreateRolesAsync();
    }
}
