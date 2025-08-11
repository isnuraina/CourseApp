using Service.DTOs.Group;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task CreateAsync(GroupCreateDto model);
        Task<IEnumerable<GroupDto>> GetAllAsync();
    }
}
