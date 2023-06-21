using ManagementPortal.Data;
using ManagementPortal.Services.Customer;
using ManagementPortal.Services.Inventory;
using ManagementPortal.Services.Order;
using ManagementPortal.Services.Product;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers().AddNewtonsoftJson(opts =>
{
  opts.SerializerSettings.ContractResolver = new
      DefaultContractResolver
  {
    NamingStrategy = new CamelCaseNamingStrategy()
  };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataDbContext>(options =>
{
  options.EnableDetailedErrors();
  options.UseNpgsql(builder.Configuration.GetConnectionString("database.dev"));
});

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IInventoryService, InventoryService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .WithOrigins(
        "http://localhost:8080",
        "http://localhost:8081",
        "http://localhost:8082"
    )
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
