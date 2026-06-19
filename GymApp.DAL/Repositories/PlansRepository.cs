using GymApp.DAL.Context;
using GymApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DAL.Repositories;

public class PlansRepository : IPlansRepository
{
    private readonly GymDbContext _context;
    
    public PlansRepository(GymDbContext context)
    {
        _context = context;
    }

    // Get All
    public async Task<IEnumerable<Plan>> GetAllAsync(bool trackchanges = false, CancellationToken cancellationToken = default)
        => trackchanges ? await _context.Plans.ToListAsync(cancellationToken)
        : await _context.Plans.AsNoTracking().ToListAsync(cancellationToken);
    // Get By Id
    public async Task<Plan?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Plans.FindAsync([id], cancellationToken);
    // Add
    public async Task AddAsync(Plan plan, CancellationToken cancellationToken = default)
    {
        _context.Plans.Add(plan);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateAsync(Plan plan, CancellationToken cancellationToken = default)
    {
        _context.Plans.Update(plan);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(Plan plan, CancellationToken cancellationToken = default)
    {
        _context.Plans.Remove(plan);
        await _context.SaveChangesAsync(cancellationToken);
    }
    // Update
    // Delete
}