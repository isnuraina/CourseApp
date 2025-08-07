using Service.DTOs.Education;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {
        Task CreateAsync(EducationCreateDto model);
        Task<IEnumerable<EducationDto>> GetAllAsync();
        Task<EducationDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(int id,EducationEditDto model);
        Task<IEnumerable<EducationDto>> SearchByNameAsync(string str);
    }
}
