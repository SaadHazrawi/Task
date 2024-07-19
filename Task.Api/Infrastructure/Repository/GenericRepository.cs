using Application.Common;
using Application.Interface.GenericRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    private readonly AppDataContext _context;
    private   DbSet<T> _dbSet;

    public GenericRepository(AppDataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.AnyAsync(filter);
    }
    public async Task<bool> AnyAsync()
    {
        return await _dbSet.AnyAsync();
    }
    public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
    {
        return await (filter == null ? _dbSet.CountAsync() : _dbSet.CountAsync(filter));
    }
    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }
    /// <summary>
    /// Get an object by its ID, with optional tracking and navigation property includes.
    /// </summary>
    /// <param name="id">The ID of the object to retrieve.</param>
    /// <param name="asNoTracking">If true, the entity will be retrieved without tracking.</param>
    /// <param name="includes">Navigation properties to include in the query.</param>
    /// <returns>The object with the specified ID, or null if not found.</returns>
    public async Task<T> GetByIdAsync(int id, bool asNoTracking, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        T entity = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

        return entity;
    }

    /// <summary>
    /// Get paginated list of objects with optional tracking, navigation property includes, and sorting.
    /// </summary>
    /// <param name="pageIndex">The index of the page to retrieve.</param>
    /// <param name="pageSize">The size of the page to retrieve.</param>
    /// <param name="asNoTracking">If true, retrieves the entities without tracking.</param>
    /// <param name="orderBy">Expression to specify the property for sorting (ascending).</param>
    /// <param name="orderByDescending">If true, sorts in descending order.</param>
    /// <param name="includes">Navigation properties to include in the query.</param>
    /// <returns>A paginated list of objects.</returns>
    public async Task<Pagination<T>> ToPagination(int pageIndex, int pageSize, bool asNoTracking,
    Expression<Func<T, bool>> where = null,
    Expression<Func<T, object>> orderBy = null,
    bool orderByDescending = false,
    params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }
        if (where != null)
        {
            query = query.Where(where);
        }
        if (orderBy != null)
        {
            if (orderByDescending)
            {
                query = query.OrderByDescending(orderBy);
            }
            else
            {
                query = query.OrderBy(orderBy);
            }
        }
        var itemCount = await query.CountAsync();
        var items = await query.Skip(pageIndex * pageSize)
                               .Take(pageSize)
                               .ToListAsync();
        var result = new Pagination<T>()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalItemsCount = itemCount,
            Items = items,
        };
        return result;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
    {
        T entity = await _dbSet.IgnoreQueryFilters()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(filter);
        return entity;
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task Delete(int id)
    {
        T entity = await GetByIdAsync(id,true,null);
        if (entity != null)
        {
            Delete(entity);
        }
    }

    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null)
    {
        IQueryable<T> query = _dbSet;
        if (where != null)
        {
            query = query.Where(where);
        }
        return await query.ToListAsync();
    }

     
}