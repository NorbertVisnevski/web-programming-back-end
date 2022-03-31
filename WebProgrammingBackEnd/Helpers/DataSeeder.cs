using WebProgrammingBackEnd.Data;
using WebProgrammingBackEnd.Entities;

namespace WebProgrammingBackEnd.Helpers
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;

        public DataSeeder(AppDbContext context)
        {
            _context = context;
        }
        public void Seed(int count)
        {
            if (!_context.Products.Any())
            {
                var products = new List<Product>();
                var category = new Category { Name = "Basic" };
                for (int i = 0; i < count; i++)
                {
                    products.Add(new Product() { Caption = $"Product{i}", Description = $"Product{i}", Categories = new List<Category> { category }, Price = 1.99, Stock = 10 });
                }
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }
    }
}
