using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Education;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(EducationCreateDto model)
        {
            await _educationRepository.CreateAsync(_mapper.Map<Education>(model));
        }

        public async Task<IEnumerable<EducationDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _educationRepository.GetAllAsync());
        }

        public async Task<EducationDto> GetByIdAsync(int id)
        {
            return _mapper.Map<EducationDto>(await _educationRepository.GetWithExpressionAsync(m => m.Id == id));
        }
    }
}
