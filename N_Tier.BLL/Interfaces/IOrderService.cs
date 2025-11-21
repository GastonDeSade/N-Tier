using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;

namespace N_Tier.BLL.Manager.Interfaces.Services;

public interface IOrderService
{
    Task<Order> GetByIdAsync(Guid id);
    Task<OrderUpDto[]> GetByUserIdAsync(string userId);
    Task AddAsync(OrderDownDto order);
    Task DeleteAsync(Guid id);
}