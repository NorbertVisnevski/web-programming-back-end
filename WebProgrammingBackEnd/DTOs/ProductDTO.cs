using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class ProductLoadDTO
{
    public int Id { get; set; }
    public string Caption { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    //public ICollection<Image> Images { get; set; }
    public ICollection<CategoryLoadDTO> Categories { get; set; }
}

public class ProductRegisterDTO
{
    [Required]
    public string Caption { get; set; }
    public string Description { get; set; }
    [Range(0.99, Double.PositiveInfinity)]
    public double Price { get; set; }
    [Range(0, Int32.MaxValue)]
    public int Stock { get; set; }
    //public ICollection<Image> Images { get; set; }
    [MinLength(1)]
    public ICollection<CategoryRegisterDTO> Categories { get; set; }
}

public class ProductEditDTO
{
    public int Id { get; set; }
    [Required]
    public string Caption { get; set; }
    public string Description { get; set; }
    [Range(0.99, Double.PositiveInfinity)]
    public double Price { get; set; }
    [Range(0, Int32.MaxValue)]
    public int Stock { get; set; }
    //public ICollection<Image> Images { get; set; }
    [MinLength(1)]
    public ICollection<CategoryEditDTO> Categories { get; set; }
}