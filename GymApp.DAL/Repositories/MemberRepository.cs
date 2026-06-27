using System.Linq.Expressions;

namespace GymApp.DAL.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{    
    public MemberRepository(GymDbContext context) : base(context)
    {
    }

    public Task<bool> AnyAsync(Expression<Func<Member, bool>> predicate, CancellationToken cancellationToken = default)
        => _context.Members.AnyAsync(predicate, cancellationToken);

    public Task<bool> EmailExistAsync(string email, CancellationToken cancellationToken = default)
        => _context.Members.AnyAsync(m => m.Email == email, cancellationToken);

    public Task<bool> PhoneExistAsync(string phone, CancellationToken cancellationToken = default)
        => _context.Members.AnyAsync(m => m.Phone == phone, cancellationToken);
}