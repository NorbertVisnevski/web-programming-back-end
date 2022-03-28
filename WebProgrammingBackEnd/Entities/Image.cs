namespace WebProgrammingBackEnd.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public byte[] File { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
