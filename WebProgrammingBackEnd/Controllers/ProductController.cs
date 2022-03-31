using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingBackEnd.Data;
using WebProgrammingBackEnd.DTOs;
using WebProgrammingBackEnd.Entities;
using WebProgrammingBackEnd.Helpers;


namespace WebProgrammingBackEnd.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams productParams)
        {

            var products = await GetProductsByParams(productParams);

            Response.AddPagination(products.CurrentPage, products.PageSize, products.TotalCount, products.TotalPages);

            return Ok(_mapper.Map<List<ProductLoadDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Categories).Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(_mapper.Map<ProductLoadDTO>(product));
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRegisterDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            product.Categories = new List<Category>();
            foreach (var entry in productDTO.Categories)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(entry.Name));
                if (category == null)
                {
                    category = new Category { Name = entry.Name };
                }
                product.Categories.Add(category);
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, _mapper.Map<ProductLoadDTO>(product));

        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductEditDTO productDTO)
        {
            var product = await _context.Products.Include(p => p.Categories).Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == productDTO.Id);
            if (product == null)
                return NotFound();
            product.Categories.Clear();
            _mapper.Map(productDTO, product);
            product.Categories.Clear();
            foreach (var entry in productDTO.Categories)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(entry.Name));
                if (category == null)
                {
                    category = new Category { Name = entry.Name };
                }
                product.Categories.Add(category);
            }
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ProductLoadDTO>(product));
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private async Task<PageList<Product>> GetProductsByParams(ProductParams productParams)
        {
            var products = _context.Products
               .Include(p => p.Categories)
               .Include(p => p.Images)
               .OrderBy(p => p.Price)
               .AsQueryable();
            if (productParams.Categories != null)
            {
                products = products.Where(x => x.Categories.Any(c => productParams.Categories.Contains(c.Name)));
            }
            if ((bool)(productParams.Order?.Equals("descending")))
            {
                products = products.OrderByDescending(x => x.Price);
            }
            if (productParams.InStock == true)
            {
                products = products.Where(x => x.Stock > 0);
            }
            if (productParams.MaxPrice != null)
            {
                products = products.Where(x => x.Price <= productParams.MaxPrice);
            }
            if (productParams.MinPrice != null)
            {
                products = products.Where(x => x.Price >= productParams.MinPrice);
            }
            return await PageList<Product>.CreateAsync(products, productParams.PageNumber, productParams.PageSize);
        }
    }
}
