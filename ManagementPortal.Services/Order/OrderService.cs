using ManagementPortal.Data;
using ManagementPortal.Data.Models;
using ManagementPortal.Services.Customer;
using ManagementPortal.Services.Inventory;
using ManagementPortal.Services.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ManagementPortal.Services.Order
{
  public class OrderService : IOrderService
  {
    private readonly DataDbContext _context;
    private readonly ILogger<OrderService> _logger;
    private readonly IInventoryService _inventoryService;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;

    public OrderService(DataDbContext context, ILogger<OrderService> logger, IInventoryService inventoryService, IProductService productService, ICustomerService customerService)
    {
      _context = context;
      _logger = logger;
      _inventoryService = inventoryService;
      _productService = productService;
      _customerService = customerService;
    }

    /// <summary>
    /// Creates an invoice for a given order
    /// </summary>
    /// <param name="order">Order to be invoiced</param>
    /// <returns></returns>
    public ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder order)
    {
      foreach (var item in order.SalesOrderItems)
      {
        item.Product = _productService.GetProduct(item.Product.Id);
        item.Quantity = item.Quantity;

        var inventoryId = _inventoryService.GetByProductId(item.Product.Id).Id;
        _inventoryService.UpdateUnitsAvailable(inventoryId, -item.Quantity);
      }

      try
      {
        _context.SalesOrders.Add(order);
        _context.SaveChanges();

        return new ServiceResponse<bool>
        {
          Data = true,
          Time = DateTime.UtcNow,
          Message = "Order created",
          IsSuccess = true
        };
      }

      catch (Exception e)
      {
        return new ServiceResponse<bool>
        {
          Data = false,
          Time = DateTime.UtcNow,
          Message = e.StackTrace,
          IsSuccess = false
        };
      }
    }

    /// <summary>
    /// Returns a list of all SalesOrders in the database
    /// </summary>
    /// <returns></returns>
    public List<SalesOrder> GetOrders()
    {
      return _context.SalesOrders
        .Include(order => order.Customer)
            .ThenInclude(customer => customer.Address)
        .Include(order => order.SalesOrderItems)
            .ThenInclude(item => item.Product)
        .ToList();
    }

    public ServiceResponse<bool> MarkFulfilled(int id)
    {
      var now = DateTime.UtcNow;
      var order = _context.SalesOrders.Find(id);
      order.Updated = now;
      order.IsPaid = true;

      try
      {
        _context.SalesOrders.Update(order);
        _context.SaveChanges();

        return new ServiceResponse<bool>
        {
          Data = true,
          Time = now,
          Message = $"Order {order.Id} closed: Invoice paid in full.",
          IsSuccess = true
        };
      }

      catch (Exception e)
      {
        return new ServiceResponse<bool>
        {
          Data = false,
          Time = now,
          Message = e.StackTrace,
          IsSuccess = false
        };
      }
    }
  }
}