namespace WebProgrammingBackEnd.Entities
{
    public class SubOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
