using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class OrderRegisterDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    public string Name { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    public string Surname { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    public string Country { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    public string City { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    public string Street { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    [Min(1, ErrorMessage = "House number should be a positive number")]
    public int HouseNumber { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string PhoneNumber { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
    public string ZipCode { get; set; }
    [Required(ErrorMessage = "Field is required")]
    public int BuyerId { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "Needs to include at least one product")]
    public ICollection<SubOrderRegisterDTO> SubOrders { get; set; }
}

public class OrderLoadDTO
{
    public int Id { get; set; }
    public double Total { get; set; }
    public string Status { get; set; }
    public DateTime OrderTime { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string ZipCode { get; set; }
    public int BuyerId { get; set; }
    public ICollection<SubOrderLoadDTO> SubOrders { get; set; }
}

public class OrderEditDTO
{
    [Required]
    public int Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Status is required")]
    public string Status { get; set; }
}