using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Group;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository, IMapper mapper, IEducationService educationService)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _educationService = educationService;
        }

        public async Task CreateAsync(GroupCreateDto model)
        {
            var education = await _educationService.GetByIdAsync(model.EducationId);
            if (education is null) throw new KeyNotFoundException("Education is not found!");
            await _groupRepository.CreateAsync(_mapper.Map<Group>(model));
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(await _groupRepository.GetAllWithIncludesAsync(m => m.Education));
                
        }
    }
}
