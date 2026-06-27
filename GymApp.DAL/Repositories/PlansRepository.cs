namespace GymApp.DAL.Repositories;

public class PlansRepository : GenericRepository<Plan>, IPlansRepository
{
    
    public PlansRepository(GymDbContext context) : base(context)
    {
    }

}