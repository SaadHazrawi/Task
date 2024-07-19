using Application.Common;
using System.Linq.Expressions;

namespace Application.Interface.GenericRepository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        public Task AddAsync(T entity);
        public Task AddRangeAsync(IEnumerable<T> entities);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        public Task<bool> AnyAsync();
        public Task<int> CountAsync(Expression<Func<T, bool>> filter);
        public Task<int> CountAsync();
        public Task<T> GetByIdAsync(int id, bool asNoTracking, params Expression<Func<T, object>>[] includes);
        Task<Pagination<T>> ToPagination(int pageIndex, int pageSize, bool asNoTracking,
    Expression<Func<T, bool>> where = null,
    Expression<Func<T, object>> orderBy = null, bool orderByDescending = false,
    params Expression<Func<T, object>>[] includes);
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null);
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        public void Update(T entity);
        public void UpdateRange(IEnumerable<T> entities);
        public void Delete(T entity);
        public void DeleteRange(IEnumerable<T> entities);
        public Task Delete(int id);
        public IQueryable<T> Query();
    }
}

