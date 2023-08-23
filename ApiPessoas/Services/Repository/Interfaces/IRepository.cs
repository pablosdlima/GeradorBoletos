using System.Linq.Expressions;

namespace ApiPessoas.Services.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> GetByIdAsync(int id);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<int> LastIdAsync(Expression<Func<T, int>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(T entity);
        Task<T> UltimoAsync(Expression<Func<T, long>> predicate);
    }
}
