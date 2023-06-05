namespace ManagementPortal.Data.Models
{
  public class ProductInventory : BaseModel
  {
    public int QuantityOnHand { get; set; }
    public int QuantityOnOrder { get; set; }
    public Product Product { get; set; }
  }
}