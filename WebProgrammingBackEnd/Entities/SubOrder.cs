using Microsoft.EntityFrameworkCore;

namespace WebProgrammingBackEnd.Entities
{
    [Owned]
    public class SubOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
