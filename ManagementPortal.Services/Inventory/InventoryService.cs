using ManagementPortal.Data;
using ManagementPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ManagementPortal.Services.Inventory
{
  public class InventoryService : IInventoryService
  {
    private readonly DataDbContext _context;
    private readonly ILogger<InventoryService> _logger;
    public InventoryService(DataDbContext context, ILogger<InventoryService> logger)
    {
      _context = context;
      _logger = logger;
    }

    public void CreateSnapshot(ProductInventory inventory)
    {
      var now = DateTime.UtcNow;

      var snapshot = new ProductInventorySnapshot
      {
        SnapshotTime = now,
        Product = inventory.Product,
        QuantityOnHand = inventory.QuantityOnHand
      };

      _context.Add(snapshot);
      _context.SaveChanges();
    }

    /// <summary>
    /// Returns the ProductInventory entity that matches the provided id
    /// </summary>
    /// <param name="productId">Product id</param>
    /// <returns></returns>
    public ProductInventory GetByProductId(int productId)
    {
      return _context.ProductInventories
          .Include(inv => inv.Product)
          .FirstOrDefault(inv => inv.Product.Id == productId);
    }

    /// <summary>
    /// Returns a list of current inventory from the database
    /// </summary>
    /// <returns></returns>
    public List<ProductInventory> GetInventory()
    {
      return _context.ProductInventories
        .Include(inv => inv.Product)
        .Where(inv => !inv.Product.IsArchived)
        .ToList();
    }

    /// <summary>
    /// Returns a list of snapshots of inventory for a given product
    /// </summary>
    /// <returns></returns>
    public List<ProductInventorySnapshot> GetSnapshotHistory()
    {
      var earliest = DateTime.UtcNow - TimeSpan.FromHours(6);

      return _context.ProductInventorySnapshots
        .Include(snap => snap.Product)
        .Where(snap => snap.SnapshotTime > earliest
                       && !snap.Product.IsArchived)
        .ToList();
    }

    /// <summary>
    /// Updates number of units available of the provided product id
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="adjustment">Number of units to adjust</param>
    /// <returns></returns>
    public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment)
    {
      var now = DateTime.UtcNow;

      try
      {
        var inventory = _context.ProductInventories
          .Include(inv => inv.Product)
          .First(inv => inv.Product.Id == id);

        inventory.QuantityOnHand += adjustment;

        try
        {
          CreateSnapshot(inventory);
        }

        catch (Exception e)
        {
          _logger.LogError("Error creating inventory snapshot");
          _logger.LogError(e.StackTrace);
        }

        _context.SaveChanges();

        return new ServiceResponse<ProductInventory>
        {
          Time = now,
          Data = inventory,
          Message = $"Product {id} inventory adjusted",
          IsSuccess = true
        };
      }

      catch
      {
        return new ServiceResponse<ProductInventory>
        {
          Time = now,
          Data = null,
          Message = $"Error updating Product {id} inventory",
          IsSuccess = false
        };
      }
    }
  }
}