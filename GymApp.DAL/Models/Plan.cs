namespace GymApp.DAL.Models;

public class Plan : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int DurationDays { get; set; } // check constraints
    public decimal Price { get; set; } // decimal(10,2)
    public bool IsActive { get; set; }   // soft-delete flag

    public ICollection<Membership> PlanMembers { get; set; } = [];
}