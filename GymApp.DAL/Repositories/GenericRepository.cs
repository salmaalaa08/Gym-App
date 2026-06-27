namespace GymApp.DAL.Contracts;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly GymDbContext _context;
    
    public GenericRepository(GymDbContext context)
    {
        _context = context;
    }

    // Get All
    public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackchanges = false, CancellationToken cancellationToken = default)
        => trackchanges ? await _context.Set<TEntity>().ToListAsync(cancellationToken)
        : await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
    // Get By Id
    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Set<TEntity>().FindAsync([id], cancellationToken);
    // Add
    public async Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Add(entity);
        return await _context.SaveChangesAsync(cancellationToken);
    }
    // Update
    public async Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Update(entity);
        return await _context.SaveChangesAsync(cancellationToken);
    }
    // Delete
    public async Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Remove(entity);
        return await _context.SaveChangesAsync(cancellationToken);
    }
}