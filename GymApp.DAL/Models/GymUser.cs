using GymApp.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DAL.Models;

public class GymUser : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }

    // Gender
    public Gender Gender { get; set; }
    // Address
    public Address Address { get; set; } = default!;
}

[Owned]
public class Address
{
    public int BuildingNumber { get; set; }
    public string Street { get; set; } = default!;
    public string City { get; set; } = default!;
}