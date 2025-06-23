namespace Basket.Infrastructure.Persistence.Repositories;

public class GenericRepository<T, TId> : IGenericRepository<T, TId>
    where T : Entity<TId>
    where TId : IEquatable<TId>
{
    protected readonly BasketDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(BasketDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);

    public async Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken) is not null;
}