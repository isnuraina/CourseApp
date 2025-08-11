using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Education;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
    public class EducationController : BaseController
    {
        private readonly IEducationService _educationService;
        private readonly ILogger<EducationController> _logger;

        public EducationController(IEducationService educationService, ILogger<EducationController> logger)
        {
            _educationService = educationService;
            _logger = logger;
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
            _logger.LogInformation("Get request received at {Time}", DateTime.UtcNow);
            var datas= await _educationService.GetAllAsync();
            return Ok(datas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
           
                return Ok(await _educationService.GetByIdAsync(id));
         
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int? id)
        {
           
                if (id is null) return BadRequest();
                await _educationService.DeleteAsync((int)id);
                return Ok();
         
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody]EducationEditDto request)
        {
           
                await _educationService.EditAsync(id, request);
                return Ok();
                     
        }
        [HttpGet]
        public async Task<IActionResult> SearchByName([FromQuery] string? searchText)
        {
            return Ok(await _educationService.SearchByNameAsync(searchText));
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginatedDatas([FromQuery] int page)
        {
            return Ok(await _educationService.GetPaginatedDatasAsync(page));
        }
    }
}
