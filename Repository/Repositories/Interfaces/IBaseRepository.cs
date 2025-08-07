using Domain.Common;
using System.Linq.Expressions;
namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetWithExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> predicate);
    }
}
