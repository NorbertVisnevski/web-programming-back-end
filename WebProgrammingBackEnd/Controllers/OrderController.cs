using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingBackEnd.Data;
using WebProgrammingBackEnd.DTOs;
using WebProgrammingBackEnd.Entities;

namespace WebProgrammingBackEnd.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders.Include(x => x.SubOrders).ThenInclude(x => x.Product).ToListAsync();
            return Ok(_mapper.Map<List<OrderLoadDTO>>(orders));
        }

        [Authorize]
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _context.Orders.Include(x => x.SubOrders).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderLoadDTO>(order));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrdersByUser([FromQuery] int userId)
        {
            var orders = await _context.Orders.Include(x => x.SubOrders).ThenInclude(x => x.Product).Where(x => x.BuyerId == userId).ToListAsync();
            return Ok(_mapper.Map<List<OrderLoadDTO>>(orders));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterOrder([FromBody] OrderRegisterDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order.SubOrders = new List<SubOrder>();
            double total = 0;
            foreach (var subOrder in orderDTO.SubOrders)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == subOrder.ProductId);
                if (product != null && product.Stock >= subOrder.Count)
                {
                    product.Stock -= subOrder.Count;
                    total += product.Price * subOrder.Count;
                    order.SubOrders.Add(new SubOrder { Product = product, Count = subOrder.Count });
                }
                else
                {
                    return BadRequest();
                }
            }
            order.Total = total;
            order.Status = "Preparing";
            _context.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RegisterOrder), new { id = order.Id }, _mapper.Map<OrderLoadDTO>(order));
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> EditOrder([FromBody] OrderEditDTO orderDTO)
        {
            var order = await _context.Orders.Include(x => x.SubOrders).FirstOrDefaultAsync(x => x.Id == orderDTO.Id);
            if (order == null)
            {
                return BadRequest();
            }
            _mapper.Map(orderDTO, order);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<OrderLoadDTO>(order));
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if(order == null)
            {
                return BadRequest();
            }
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
