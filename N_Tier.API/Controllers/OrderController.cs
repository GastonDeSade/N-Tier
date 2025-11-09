using Microsoft.AspNetCore.Mvc;
using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;

namespace N_Tier.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDto order)
    { 
        await _orderService.AddAsync(order);
        return Created((Uri?)null, order);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound();
        await _orderService.DeleteAsync(id);
        return NoContent();
    }
}