using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingBackEnd.Data;
using WebProgrammingBackEnd.DTOs;
using WebProgrammingBackEnd.Entities;

namespace WebProgrammingBackEnd.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(_mapper.Map<List<CategoryLoadDTO>>(categories));
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult> GetCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryLoadDTO>(category));
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> PutCategory(CategoryEditDTO category)
        {
            var categoryFromRepo = await _context.Categories.FindAsync(category.Id);
            if (categoryFromRepo == null)
                return NotFound();
            var categorySameName = await _context.Categories.FirstOrDefaultAsync(x => x.Name.Equals(category.Name));
            if (categorySameName != null)
            {
                return BadRequest(new { errors = new { Name = new[] { "Category name already in use" } } });
            }
            _mapper.Map(category, categoryFromRepo);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<CategoryLoadDTO>(categoryFromRepo));
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostCategory(CategoryRegisterDTO category)
        {
            var _category = await _context.Categories.FirstOrDefaultAsync(x => x.Name.Equals(category.Name));
            if (_category != null)
            {
                return BadRequest(new { errors = new { Name = new[] { "Category name already in use" } } });
            }
            _category = _mapper.Map<Category>(category);
            await _context.Categories.AddAsync(_category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategories), new { id = _category.Id }, _mapper.Map<CategoryLoadDTO>(_category));
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
