namespace ManagementPortal.Web.ViewModels
{
  public class InvoiceModel
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public int CustomerId { get; set; }
    public List<SalesOrderItemModel> LineItems { get; set; }
  }

  public class SalesOrderItemModel
  {
    public int Id { get; set; }
    public int Quantity { get; set; }
    public ProductModel Product { get; set; }
  }
}