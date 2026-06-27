using GymApp.DAL.Models;

namespace GymApp.BLL;

public interface IPlansService
{
    Task<IEnumerable<Plan>> PlansAsync(CancellationToken cancellationToken = default);
    Task<Plan?> GetPlanByIdAsync(int id, CancellationToken cancellationToken = default);
}