using ManagementPortal.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagementPortal.Data
{
  public class DataDbContext : IdentityDbContext
  {
    public DataDbContext()
    {
    }

    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductInventory> ProductInventories { get; set; }
    public virtual DbSet<ProductInventorySnapshot> ProductInventorySnapshots { get; set; }
    public virtual DbSet<SalesOrder> SalesOrders { get; set; }
    public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }
  }
}