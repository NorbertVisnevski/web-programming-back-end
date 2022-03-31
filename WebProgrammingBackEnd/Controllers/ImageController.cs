using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingBackEnd.Data;
using WebProgrammingBackEnd.Entities;

namespace WebProgrammingBackEnd.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ImageController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<ActionResult> UploadImages([FromForm] ICollection<IFormFile> files, [FromQuery] int productId)
        {
            var product = await _context.Products.Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null || files.Count == 0)
                return NotFound("Resource not found");

            var allowedFiles = new[] { "jpg", "png" };
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName).Substring(1);
                if (!allowedFiles.Contains(extension))
                {
                    return BadRequest("Files should be images");
                }
                if (file.Length > 1e6)
                {
                    return BadRequest("File exceeds max size of 1MB");
                }
                var image = new Image { Type = extension };
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    image.File = fileBytes;
                }
                product.Images.Add(image);
            }
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<List<int>>(product.Images));
        }

        [HttpGet("{imageId}")]
        public async Task<ActionResult> RetrieveImage(int imageId)
        {
            var image = await _context.Images.FindAsync(imageId);
            return File(image.File, "image/" + image.Type);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{imageId}")]
        public async Task<ActionResult> DeleteImage(int imageId)
        {
            var image = await _context.Images.FindAsync(imageId);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
