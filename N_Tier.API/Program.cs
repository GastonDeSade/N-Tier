using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using N_Tier.BLL.Entities;
using N_Tier.BLL.Manager.Interfaces.Services;
using N_Tier.BLL.Manager.Services;
using N_Tier.BLL.Services;
using Scalar.AspNetCore;
using N_Tier.API.Extensions;
using N_Tier.DAL.Interfaces;
using N_Tier.DAL.Repositories;
using N_Tier.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddOpenApi();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

// ======================
// ConfigureServices()
// ======================

// Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("N_Tier.DAL")
    ));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Managers (BLL)
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Services (Application Layer)
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Controllers
builder.Services.AddControllers();

// ======================
// Build + Configure()
// ======================
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();   
    app.MapScalarApiReference();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapIdentityApi<User>();
app.MapControllers();

app.Run();