using N_Tier.BLL.DTOs;
using N_Tier.BLL.Manager.Interfaces.Services;

namespace N_Tier.API.Extensions;

public static class FakeDataExtensions
{
    public static async Task SeedAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
        
        var existing = await productService.GetByNameAsync("Parfum L'obsession");
        if (existing != null && existing.Length > 0)
        {
            return; // Data already seeded
        }
        
        // Create Products
        ProductDto product1 = new ProductDto
        {
            Name = "Parfum L'obsession",
            Description = "Parfum L'obsession, un parfum d'exception.",
            Price = 999.99f,
            Image = "/public/img/l_obsession.webp",
            Image2 = "/public/img/l_obsession2.webp",
            Image3 = "/public/img/l_obsession3.webp",
            Image4 = "/public/img/l_obsession4.webp"
        };

        ProductDto product2 = new ProductDto
        {
            Name = "Parfum La tendance",
            Description = "Parfum La tendance, il vous assure d'être toujours frais.",
            Price = 699.99f,
            Image = "/public/img/la_tendance.webp",
            Image2 = "/public/img/la_tendance2.webp",
            Image3 = "/public/img/la_tendance3.webp",
            Image4 = "/public/img/la_tendance4.webp"
            
        };

        ProductDto product3 = new ProductDto
        {
            Name = "Parfum Le désir",
            Description = "Parfum Le désir, un parfum captivant.",
            Price = 199.99f,
            Image = "/public/img/le_desir.webp",
            Image2 = "/public/img/le_desir2.webp",
            Image3 = "/public/img/le_desir3.webp",
            Image4 = "/public/img/le_desir4.webp"
        };

        ProductDto product4 = new ProductDto
        {
            Name = "Parfum L'élégance",
            Description = "Parfum L'élégance, pour une allure sophistiquée.",
            Price = 499.99f,
            Image = "/public/img/l_elegance.webp",
            Image2 = "/public/img/l_elegance2.webp",
            Image3 = "/public/img/l_elegance3.webp",
            Image4 = "/public/img/l_elegance4.webp"
        };
        
        ProductDto product5 = new ProductDto
        {
            Name = "Parfum La séduction",
            Description = "Parfum La séduction, un parfum irrésistible.",
            Price = 299.99f,
            Image = "/public/img/la_seduction.webp",
            Image2 = "/public/img/la_seduction2.webp",
            Image3 = "/public/img/la_seduction3.webp",
            Image4 = "/public/img/la_seduction4.webp"
        };
        
        ProductDto product6 = new ProductDto
        {
            Name = "Parfum Le charme",
            Description = "Parfum Le charme, pour un charme inoubliable.",
            Price = 399.99f,
            Image = "/public/img/le_charme.webp",
            Image2 = "/public/img/le_charme2.webp",
            Image3 = "/public/img/le_charme3.webp",
            Image4 = "/public/img/le_charme4.webp"
        };
        
        await productService.AddAsync(product2);
        await productService.AddAsync(product6);
        await productService.AddAsync(product5);
        await productService.AddAsync(product4);
        await productService.AddAsync(product3);
        await productService.AddAsync(product1);
    }
}