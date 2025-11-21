using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;

namespace N_Tier.BLL.Manager.Interfaces.Services;

public interface IProductService
{
   Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int page, int pageSize);
   Task<Product> GetByIdAsync(Guid id);
   Task<Product[]> GetByNameAsync(string name);
   Task<Product> AddAsync(ProductDto product);
   Task UpdateAsync(ProductDto product);
   Task DeleteAsync(Guid id);
}