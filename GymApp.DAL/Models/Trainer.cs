using GymApp.DAL.Models.Enums;

namespace GymApp.DAL.Models;

public class Trainer : GymUser
{
    public Specialities Speciality { get; set; }

    // Hire Date => property or from CreatedAt in BaseEntity

    public ICollection<Session> Sessions { get; set; } = [];
}