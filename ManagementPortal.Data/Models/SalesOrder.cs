namespace ManagementPortal.Data.Models
{
  public class SalesOrder : BaseModel
  {
    public Customer Customer { get; set; }
    public List<SalesOrderItem> SalesOrderItems { get; set; }
    public bool IsPaid { get; set; }
  }
}