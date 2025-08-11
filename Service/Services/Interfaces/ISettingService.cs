using Service.DTOs.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ISettingService
    {
        Task CreateAsync(SettingCreateDto model);
    }
}
  