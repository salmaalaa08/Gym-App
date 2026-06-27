using System.ComponentModel.DataAnnotations;
using GymApp.DAL.Models.Enums;

namespace GymApp.BLL.ViewModels.Member;

public class CreateMemberViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [RegularExpression("[a-zA-Z]+$", ErrorMessage = "Name can only contain letters and spaces")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Phone is required")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = default!;

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; } = default!;

    [Required(ErrorMessage = "Gender is required")]
    public Gender Gender { get; set; }

    // Address Properties
    [Required(ErrorMessage = "Building number is requires")]
    public int BuildingNumber { get; set; }

    [Required(ErrorMessage = "Street is requires")]
    public string Street { get; set; } = default!;

    [Required(ErrorMessage = "City is requires")]
    public string City { get; set; } = default!;

    [Required(ErrorMessage = "Health record is requires")]
    public HealthRecordViewModel HealthRecord { get; set; } = default!;
}