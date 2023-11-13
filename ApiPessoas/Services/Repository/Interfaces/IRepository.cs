using System.Linq.Expressions;

namespace ApiPessoas.Services.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> GetByIdAsync(long id);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<long> LastIdAsync(Expression<Func<T, long>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(T entity);
        Task<T> UltimoAsync(Expression<Func<T, long>> predicate);
    }
}
