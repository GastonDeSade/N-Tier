using Microsoft.EntityFrameworkCore;
using N_Tier.BLL.Entities;
using N_Tier.DAL.Interfaces;
using N_Tier.DAL.Repository;

namespace N_Tier.DAL.Repositories
{
    public class OrderRepository(ApplicationDbContext context) : IOrderRepository
    {
        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await context.Orders
                .Include(o => o.OrderProducts)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId)
        {
            var orders = await context.Orders
                .Where(o => o.User.Id == userId)
                .Include(o => o.OrderProducts)
                .ToListAsync();
            if (orders == null || orders.Count == 0)
            {
                throw new Exception("No orders found for the specified user.");
            }
            return orders;
        }
        
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.Include(o => o.OrderProducts).ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
        }
        
    }
}