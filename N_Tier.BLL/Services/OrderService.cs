using Microsoft.AspNetCore.Identity;
using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;
using N_Tier.DAL.Interfaces;

namespace N_Tier.BLL.Services;

public class OrderService(
    IOrderRepository orderRepository,
    UserManager<User> userManager,
    IProductRepository productRepository,
    IOrderService orderService)
    : IOrderService
{
    public async Task<Order> GetByIdAsync(Guid id)
    {
        return await orderRepository.GetByIdAsync(id);
    }

    public async Task<OrderUpDto[]> GetByUserIdAsync(string userId)
    {
        var orders = await orderRepository.GetByUserIdAsync(userId);
        
        var orderDtos = orders.Select(o => new OrderUpDto
        {
            Id = o.Id,
            Created = o.Created,
            Modified = o.Modified,
            OrderProducts = o.OrderProducts.Select(op => new OrderProductDownDto
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity
            }).ToList()
        }).ToList();
        
        return orderDtos.ToArray();
    }

    public async Task<OrderUpDto> AddAsync(OrderDownDto order)
    {
        var user = await userManager.FindByIdAsync(order.idUser);
        if (user == null)
            throw new Exception("Utilisateur introuvable");
        
        var orderEntity = new Order()
        {
            Id = new Guid(),
            Modified = new DateTime(),
            Created = new DateTime(),
            User = user,
        };
        
        var orderProducts = new List<OrderProduct>();
        
        foreach (var op in order.OrderProducts)
        {
            var product = await productRepository.GetByIdAsync(op.ProductId);
            if (product == null)
                throw new Exception($"Produit introuvable: {op.ProductId}");
            orderProducts.Add(new OrderProduct
            {
                OrderId = orderEntity.Id,
                Order = orderEntity,
                ProductId = op.ProductId,
                Product = product,
                Quantity = op.Quantity
            });
        }
        
        orderEntity.OrderProducts = orderProducts;
        
        await orderRepository.AddAsync(orderEntity);
        
        return new OrderUpDto()
        {
            Id = orderEntity.Id,
            Created = orderEntity.Created,
            Modified = orderEntity.Modified,
            OrderProducts = orderEntity.OrderProducts.Select(op => new OrderProductDownDto
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity
            }).ToList()
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await orderService.GetByIdAsync(id);
        if (order == null)
            throw new Exception("Commande introuvable");
        await orderRepository.DeleteAsync(id);
    }
}