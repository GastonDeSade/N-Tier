using Microsoft.AspNetCore.Identity;
using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;
using N_Tier.DAL.Interfaces;

namespace N_Tier.BLL.Services;

public class OrderService : IOrderService
{ 
    private readonly IOrderRepository _orderRepository;
    private readonly UserManager<User> _userManager;

    public OrderService(IOrderRepository orderRepository, UserManager<User> userManager)
    {
        _orderRepository = orderRepository;
        _userManager = userManager;
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(OrderDto order)
    {
        var user = await _userManager.FindByIdAsync(order.idUser);
        if (user == null)
            throw new Exception("Utilisateur introuvable");

        float total = 0;
        foreach (var orderProduct in order.OrderProducts)
        {
            total += (orderProduct.Product.Price  * orderProduct.Quantity);
        }

        var orderEntity = new Order()
        {
            Id = new Guid(),
            Modified = new DateTime(),
            Created = new DateTime(),
            OrderProducts =  order.OrderProducts,
            User = user ,
            TotalOrder = total,
        };
        await _orderRepository.AddAsync(orderEntity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _orderRepository.DeleteAsync(id);
    }
}