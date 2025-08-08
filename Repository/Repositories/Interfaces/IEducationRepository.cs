using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository:IBaseRepository<Education>
    {
        Task<IEnumerable<Education>> GetPaginatedDatasAsync(int page, int take);
        Task<int> GetCountAsync();
    }
}
