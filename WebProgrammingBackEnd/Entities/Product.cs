namespace WebProgrammingBackEnd.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        //public ICollection<Image> Images { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
