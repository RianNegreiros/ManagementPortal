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

    public DbSet<Models.Customer> Customers { get; set; }
    public DbSet<Models.CustomerAddress> CustomerAddresses { get; set; }
  }
}