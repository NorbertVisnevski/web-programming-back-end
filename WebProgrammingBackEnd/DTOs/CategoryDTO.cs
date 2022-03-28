using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class CategoryLoadDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CategoryRegisterDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required")]
    public string Name { get; set; }
}

public class CategoryEditDTO
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required")]
    public string Name { get; set; }
}