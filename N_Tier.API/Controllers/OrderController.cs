using Microsoft.AspNetCore.Mvc;
using N_Tier.BLL.DTOs;
using N_Tier.BLL.Manager.Interfaces.Services;

namespace N_Tier.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDownDto order)
    { 
        await orderService.AddAsync(order);
        return Created((Uri?)null, order);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await orderService.GetByIdAsync(id);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpGet("{userId}/by-user")]
    public async Task<IActionResult> GetOrdersByUserId(string userId)
    {
        var orders = await orderService.GetByUserIdAsync(userId);
        if (orders == null || orders.Length == 0) return NotFound();
        return Ok(orders);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {

        await orderService.DeleteAsync(id);
        return NoContent();
    }
}