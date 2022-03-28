using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class ProductLoadDTO
{
    public int Id { get; set; }
    public string Caption { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public ICollection<int> Images { get; set; }
    public ICollection<CategoryLoadDTO> Categories { get; set; }
}

public class ProductRegisterDTO
{
    [Required(ErrorMessage = "Caption is required")]
    public string Caption { get; set; }
    public string Description { get; set; }
    [Min(0.99, ErrorMessage = "Should cost a least € 0.99")]
    public double Price { get; set; }
    [Min(0, ErrorMessage = "Can't have negative stock")]
    public int Stock { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "Sould contain at least onne category")]
    public ICollection<CategoryRegisterDTO> Categories { get; set; }
}

public class ProductEditDTO
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Caption is required")]
    public string Caption { get; set; }
    public string Description { get; set; }
    [Min(0.99, ErrorMessage = "Should cost a least € 0.99")]
    public double Price { get; set; }
    [Min(0, ErrorMessage = "Can't have negative stock")]
    public int Stock { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "Sould contain at least onne category")]
    public ICollection<CategoryEditDTO> Categories { get; set; }
}