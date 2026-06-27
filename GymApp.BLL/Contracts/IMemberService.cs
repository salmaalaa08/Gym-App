using GymApp.BLL.ViewModels.Member;
using GymApp.DAL.Models;

namespace GymApp.BLL;

public interface IMemberService
{
    Task<IEnumerable<MemberViewModel>> GetMembersAsync(CancellationToken cancellationToken = default);

    Task<bool> CreateMemberAsync(CreateMemberViewModel createMemberViewModel ,CancellationToken cancellationToken = default);
    
}
