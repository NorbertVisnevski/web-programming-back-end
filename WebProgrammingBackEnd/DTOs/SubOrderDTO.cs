using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class SubOrderRegisterDTO
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    [Min(1)]
    public int Count { get; set; }
}

public class SubOrderLoadDTO
{
    public int Id { get; set; }
    public ProductLoadDTO Product { get; set; }
    public int Count { get; set; }
}