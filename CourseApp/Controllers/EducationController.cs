using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Education;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
    public class EducationController : BaseController
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EducationCreateDto request)
        {
            await _educationService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created Success");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas= await _educationService.GetAllAsync();
            return Ok(datas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(await _educationService.GetByIdAsync(id));
        }
    }
}
