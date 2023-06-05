using ManagementPortal.Data.Models;

namespace ManagementPortal.Services.Inventory
{
  public interface IInventoryService
  {
    public List<ProductInventory> GetInventory();
    public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);
    public ProductInventory GetByProductId(int productId);
    public void CreateSnapshot(ProductInventory inventory);
    public List<ProductInventorySnapshot> GetSnapshotHistory();
  }
}