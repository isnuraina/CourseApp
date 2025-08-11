using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Setting;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
   
    public class SettingController : BaseController
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SettingCreateDto request)
        {
            await _settingService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created success");
        }
    }
}
