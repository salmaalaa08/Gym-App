using GymApp.DAL.Contracts;

namespace GymApp.BLL.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<bool> CreateMemberAsync(CreateMemberViewModel createMemberViewModel, CancellationToken cancellationToken = default)
    {
        // Check Email and Phone must be unique and valid
        // var members = await _memberRepository.GetAllAsync(cancellationToken: cancellationToken);

        // var emailExists = members.Any(m => m.Email == createMemberViewModel.Email);
        // var phoneExists = members.Any(m => m.Phone == createMemberViewModel.Phone);
        // if(emailExists || phoneExists)
        //     return false;

        var emailExists = await _memberRepository.EmailExistAsync(createMemberViewModel.Email, cancellationToken);
        var phoneExists = await _memberRepository.PhoneExistAsync(createMemberViewModel.Phone, cancellationToken);
        if(emailExists || phoneExists)
            return false;

        // Mapping => CreateMemberViewModel => Member (Manual Mapping)
        var member = new Member
        {
            Name = createMemberViewModel.Name,
            Email = createMemberViewModel.Email,
            Phone = createMemberViewModel.Phone,
            DateOfBirth = createMemberViewModel.DateOfBirth,
            Address = new Address
            {
                BuildingNumber = createMemberViewModel.BuildingNumber,
                Street = createMemberViewModel.Street,
                City = createMemberViewModel.City
            },
            Gender = createMemberViewModel.Gender,
            Photo = "",
            HealthRecord = new HealthRecord
            {
                Height = createMemberViewModel.HealthRecord.Height,
                Weight = createMemberViewModel.HealthRecord.Width,
                BloodType = createMemberViewModel.HealthRecord.BloodType,
                Note = createMemberViewModel.HealthRecord.Note
            }
        };

        // Create Member
        var result = await _memberRepository.AddAsync(member, cancellationToken: cancellationToken);

        // return
        return result > 0;
    }

    public async Task<IEnumerable<MemberViewModel>> GetMembersAsync(CancellationToken cancellationToken = default)
    {
        // Call DB => MemberRepo => GenericRepo<Member>

        // MemberRepo => Get All
        var members = await _memberRepository.GetAllAsync(cancellationToken: cancellationToken);

        // Mapping => Member => MemberViewModel
        var result = members.Select(m => new MemberViewModel
        {
            Id = m.Id,
            Name = m.Name,
            Phone = m.Phone,
            Gender = m.Gender.ToString(),
            Photo = m.Photo,
            Email = m.Email
        }).ToList();

        // ProjectTo<MemberViewModel>()
        return result;

    }
}