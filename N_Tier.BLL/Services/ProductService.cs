using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;
using N_Tier.DAL.Interfaces;

namespace N_Tier.BLL.Manager.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
    {
        return await productRepository.GetPagedAsync(page, pageSize);
    }


    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await productRepository.GetByIdAsync(id);
    }
    
    public async Task<Product[]> GetByNameAsync(string name)
    {
        var (items, _) = await productRepository.GetPagedAsync(1, 100);
        return items.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToArray();
    }

    public async Task<Product> AddAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Image = productDto.Image,
            Image2 = productDto.Image2,
            Image3 = productDto.Image3,
            Image4 = productDto.Image4
        };
        await productRepository.AddAsync(product);
        return product;
    }

    public async Task UpdateAsync(ProductDto product)
    {
        var productToUpdate = await productRepository.GetByIdAsync(product.Id);
        if (productToUpdate == null)
        {
            throw new Exception("Product not found");
        }
        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        await productRepository.UpdateAsync(productToUpdate);
    }

    public async Task DeleteAsync(Guid id)
    {
        await productRepository.DeleteAsync(id);
    }
}