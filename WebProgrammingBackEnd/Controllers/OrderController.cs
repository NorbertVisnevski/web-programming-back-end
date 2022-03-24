using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> RegisterOrder([FromBody]OrderRegisterDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order.OrderTime = DateTime.Now;
            order.SubOrders = new List<SubOrder>();
            double total = 0;
            foreach(var subOrder in orderDTO.SubOrders)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == subOrder.ProductId);
                if(product != null && product.Stock >= subOrder.Count)
                {
                    product.Stock -= subOrder.Count;
                    total += product.Price * subOrder.Count;
                    order.SubOrders.Add(new SubOrder { Product = product, Count = subOrder.Count});
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
    }
}
