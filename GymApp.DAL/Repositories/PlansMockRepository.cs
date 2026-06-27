using GymApp.DAL.Repositories;

namespace DAL.Repositories;

public class PlansMockRepository // : IPlansRepository
{
    private static List<Plan> _plans = new List<Plan>
    {
        new Plan { Id = 1, Name = "Plan A", Description = "Description for Plan A", Price = 29.99m},
        new Plan { Id = 2, Name = "Plan B", Description = "Description for Plan B", Price = 49.99m},
        new Plan { Id = 3, Name = "Plan C", Description = "Description for Plan C", Price = 69.99m},
    };
    public Task<IEnumerable<Plan>> GetAllAsync(bool trackchanges = false, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_plans.AsEnumerable());
    }
    public Task<Plan?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var plan = _plans.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(plan);
    }
}
