using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using WebProgrammingBackEnd.Validators;

namespace WebProgrammingBackEnd.DTOs;

public class UserRegisterDTO
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [EmailNotInUse(ErrorMessage = "Email address is already taken")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
    public string PasswordRepeat { get; set; }
}
public class UserLoginDTO
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}

public class UserEditDTO
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    [Min(1, ErrorMessage = "House number should be a positive number")]
    public int? HouseNumber { get; set; }
    public string PhoneNumber { get; set; }

}

public class UserLoadDTO
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int? HouseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<string> Roles { get; set; }
}