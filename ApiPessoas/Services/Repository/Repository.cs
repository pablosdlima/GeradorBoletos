using ApiPessoas.Model.Data;
using ApiPessoas.Services.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiPessoas.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }


        public async Task<T> GetByIdAsync(long id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;

                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<long> LastIdAsync(Expression<Func<T, long>> predicate)
        {
            return await _context.Set<T>().MaxAsync(predicate);
        }

        public async Task<T> UltimoAsync(Expression<Func<T, long>> predicate)
        {
            try
            {
                return await Get().OrderByDescending(predicate).Take(1).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}