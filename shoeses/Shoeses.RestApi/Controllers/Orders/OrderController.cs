using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoeses.Services.Orders.Contracts.Dtos;
using Shoeses.Services.Orders.Contracts;
using Shoeses.Services.Orders.Contracts.Exeptions;

namespace Shoeses.RestApi.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task Add([FromBody] AddOrderDto dto)
        {
            await _orderService.Add(dto);
        
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdateOrderDto dto)
        {
            await _orderService.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _orderService.Delete(id);
            
        }

        [HttpGet]
        public async Task<List<GetOrderDto>> GetAll()
        {
           return await _orderService.GetAll();
    
        }

        [HttpGet("{id}")]
        public async Task<GetOrderDto> GetById(int id)
        {
           return await _orderService.GetById(id);
           
        }
        [HttpGet("{orderId}/payments")]
        public async Task<IActionResult> GetPaymentsByOrderId(int orderId)
        {
            try
            {
                var payments = await _orderService.GetPaymentsByOrderId(orderId);
                return Ok(payments);
            }
            catch (OrderNotFoundException)
            {
                return NotFound($"Order with ID {orderId} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
