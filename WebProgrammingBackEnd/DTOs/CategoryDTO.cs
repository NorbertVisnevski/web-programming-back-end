using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class CategoryLoadDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CategoryRegisterDTO
{
    [Required]
    public string Name { get; set; }
}

public class CategoryEditDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}