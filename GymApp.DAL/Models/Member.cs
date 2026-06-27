namespace GymApp.DAL.Models;

public class Member : GymUser
{
    public string Photo { get; set; } = default!;

    // Join Date => property or from CreatedAt in BaseEntity
    // public DateOnly JoinDate { get; set; }
    
    public ICollection<Membership> MemberPlans { get; set; } = [];
    public HealthRecord HealthRecord { get; set; } = default!;
    public ICollection<Booking> MemeberSessions { get; set; } = [];
}