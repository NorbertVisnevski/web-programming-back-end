using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<CategoryLoadDTO>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(_mapper.Map<List<CategoryLoadDTO>>(categories));
        }

        [HttpPut]
        public async Task<IActionResult> PutCategory(CategoryEditDTO category)
        {
            var _category = await _context.Categories.FindAsync(category.Id);
            if(_category == null)
                return NotFound();
            _mapper.Map(category, _category);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<CategoryLoadDTO>(_category));
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryRegisterDTO category)
        {
            var _category = _mapper.Map<Category>(category);
            await _context.Categories.AddAsync(_category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategories), new { id = _category.Id }, _mapper.Map<CategoryLoadDTO>(_category));
        }

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
