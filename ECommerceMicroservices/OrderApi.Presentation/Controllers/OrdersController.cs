using eCommerce.SharedLibrary.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.DTOs.Conversions;
using OrderApi.Application.Interfaces;
using OrderApi.Application.Services;

namespace OrderApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController(IOrder orderInterface, IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await orderInterface.GetAllAsync();
            if (!orders.Any()) 
                return NotFound("Not order detected in the database");

            return Ok(orders.ToDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await orderInterface.FindByIdAsync(id);
            if (order is null)
                return NotFound(null);

            return Ok(order.ToDto());
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<OrderDTO>> GetClientOrders(int clientId)
        {
            if (clientId <= 0) return BadRequest("Invalid data provided");
            var orders = await orderService.GetOrdersByClientId(clientId);
            return orders.Any()
                ? Ok(orders)
                : NotFound(null);
        }

        [HttpGet("details/{orderId}")]
        public async Task<ActionResult<OrderDetailsDTO>> GetOrderDetails (int orderId)
        {
            if (orderId <= 0) return BadRequest("Invalid data provided");
            var orderDetail = await orderService.GetOrderDetails(orderId);
            return orderDetail.OrderId > 0
                ? Ok(orderDetail)
                : NotFound("No order found");
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateOrder(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incomplete data submitted");

            var getEntity = orderDTO.ToEntity();
            var response = await orderInterface.CreateAsync(getEntity);
            return response.Flag ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> UpdateOrder (OrderDTO orderDTO)
        {
            var order = orderDTO.ToEntity();

            var response = await orderInterface.UpdateAsync(order);

            return response.Flag ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteOrder(OrderDTO orderDTO)
        {
            var order = orderDTO.ToEntity();

            var response = await orderInterface.DeleteAsync(order);

            return response.Flag ? Ok(response) : BadRequest(response);
        }
    }
}
