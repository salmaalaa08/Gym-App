using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.DAL.Models;

public class Membership : BaseEntity
{
    public Member Member { get; set; } = default!;
    public Plan Plan { get; set; } = default!;
    public int PlanId { get; set; }
    public int MemberId { get; set; }

    // Start date => BaseEntity.CreateAt

    public DateOnly EndDate { get; set; }

    // IsActive EndDate > CurrentDate
    [NotMapped] // or ignored
    public bool IsActive => EndDate > DateOnly.FromDateTime(DateTime.Now);

    // string Status
    [NotMapped]
    public string Status => IsActive ? "Active" : "InActive";
}