using N_Tier.BLL.Entities;

namespace N_Tier.DAL.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int page, int pageSize);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}