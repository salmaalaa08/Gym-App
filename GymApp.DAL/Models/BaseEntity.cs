namespace GymApp.DAL.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    // Created By
    // Updated By
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}