using GymApp.DAL.Models;

namespace GymApp.DAL.Repositories;

public interface IPlansRepository
{
    Task<IEnumerable<Plan>> GetAllAsync(bool trackChanges = false, CancellationToken cancellationToken = default);
    Task<Plan?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}