namespace ManagementPortal.Web.ViewModels
{
  public class OrderModel
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public CustomerModel Customer { get; set; }
    public List<SalesOrderItemModel> LineItems { get; set; }
    public bool IsPaid { get; set; }
  }
}