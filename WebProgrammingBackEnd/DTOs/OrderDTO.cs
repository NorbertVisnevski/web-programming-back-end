using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.DTOs;

public class OrderRegisterDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string ZipCode { get; set; }
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
    public string HouseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string ZipCode { get; set; }
    public ICollection<SubOrderLoadDTO> SubOrders { get; set; }
}

public class OrderEditDTO
{
    public int Id { get; set; }
    public string Status { get; set; }
}