using Microsoft.AspNetCore.Mvc;
using N_Tier.BLL.DTOs;
using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;

namespace N_Tier.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts(int page = 1, int pageSize = 10)
    {
        return Ok(await _productService.GetPagedAsync(page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("{name}/by-name")]
    public async Task<IActionResult> GetProductByName(string name)
    {
        Product[] product = await _productService.GetByNameAsync(name);
        if (product == null) return NotFound();
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        var product = await _productService.AddAsync(productDto);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
    {
        await _productService.UpdateAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _productService.DeleteAsync(id);
        return NoContent();
    }
}