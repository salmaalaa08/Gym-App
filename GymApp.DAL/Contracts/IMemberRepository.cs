using System.Linq.Expressions;

namespace GymApp.DAL.Contracts;

public interface IMemberRepository : IGenericRepository<Member>
{
        Task<bool> EmailExistAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> PhoneExistAsync(string phone, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync (Expression<Func<Member, bool>> predicate ,CancellationToken cancellationToken = default);

}