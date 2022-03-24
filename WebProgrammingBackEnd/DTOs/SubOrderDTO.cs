using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class SubOrderRegisterDTO
{
    public int ProductId { get; set; }
    public int Count { get; set; }
}

public class SubOrderLoadDTO
{
    public int Id { get; set; }
    public ProductLoadDTO Product { get; set; }
    public int Count { get; set; }
}