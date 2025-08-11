using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Group;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDto request)
        {
            await _groupService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created successfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupService.GetAllAsync());
        }
    }
}
