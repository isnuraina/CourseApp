using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Education;
using Service.Helpers;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;

        public EducationService(IEducationRepository educationRepository, IMapper mapper, ISettingRepository settingRepository)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
            _settingRepository = settingRepository;
        }
        public async Task CreateAsync(EducationCreateDto model)
        {
            await _educationRepository.CreateAsync(_mapper.Map<Education>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var existEducation = await _educationRepository.GetWithExpressionAsync(m => m.Id == id);
            if (existEducation is null) throw new NotFoundException();
            await _educationRepository.DeleteAsync(existEducation);
        }

        public async Task EditAsync(int id, EducationEditDto model)
        {
            var dbEducation = await _educationRepository.GetWithExpressionAsync(m => m.Id == id);
            if (dbEducation is null) throw new NotFoundException();
            _mapper.Map(model, dbEducation);
            await _educationRepository.EditAsync(dbEducation);
        }

        public async Task<IEnumerable<EducationDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _educationRepository.GetAllAsync());
        }

        public async Task<EducationDto> GetByIdAsync(int id)
        {
            var education = await _educationRepository.GetWithExpressionAsync(m => m.Id == id);
            if (education is null) throw new NotFoundException();
            return _mapper.Map<EducationDto>(education);
        }

        public async Task<Paginate<EducationDto>> GetPaginatedDatasAsync(int page)
        {
            var settings = await _settingRepository.GetAllAsync();
            int pageTake = settings.FirstOrDefault().EducationPageTake;
            var paginatedDatas= await _educationRepository.GetPaginatedDatasAsync(page,pageTake);
            var mappedDatas= _mapper.Map<IEnumerable<EducationDto>>(paginatedDatas);
            int educationsCount = await _educationRepository.GetCountAsync();
            int pageCount =(int)Math.Ceiling((decimal)educationsCount / pageTake);
            return new Paginate<EducationDto>(mappedDatas,pageCount,page);
        }

        public async Task<IEnumerable<EducationDto>> SearchByNameAsync(string str)
        {
            var datas = await _educationRepository.GetAllWithExpressionAsync(str is null ? null : m => m.Name.Contains(str));
            return _mapper.Map<IEnumerable<EducationDto>>(datas);
        }
    }
}
