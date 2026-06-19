using GymApp.DAL.Repositories;
using GymApp.DAL.Models;

namespace GymApp.BLL;

public class PlansService : IPlansService
{
    // private readonly PlansRepository _plansRepository;
    // public PlansService(PlansRepository plansRepository)
    // {
    //     _plansRepository = plansRepository;
    // }
    // private readonly PlansMockRepository _plansRepository;
    // public PlansService(PlansMockRepository plansRepository) => _plansRepository = plansRepository;

    private readonly IPlansRepository _plansRepository;

    public PlansService(IPlansRepository plansRepository) => _plansRepository = plansRepository;

    public async Task<IEnumerable<Plan>> PlansAsync(CancellationToken cancellationToken = default)
    {
        return await _plansRepository.GetAllAsync(trackChanges: false, cancellationToken: cancellationToken);
    }

    public async Task<Plan?> GetPlanByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _plansRepository.GetByIdAsync(id, cancellationToken);
    }
}