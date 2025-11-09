using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;
using N_Tier.DAL.Interfaces;

namespace N_Tier.BLL.Manager.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
    {
        return await _productRepository.GetPagedAsync(page, pageSize);
    }


    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product> AddAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price
        };
        await _productRepository.AddAsync(product);
        return product;
    }

    public async Task UpdateAsync(ProductDto product)
    {
        var productToUpdate = await _productRepository.GetByIdAsync(product.Id);
        if (productToUpdate == null)
        {
            throw new Exception("Product not found");
        }
        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        await _productRepository.UpdateAsync(productToUpdate);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
}