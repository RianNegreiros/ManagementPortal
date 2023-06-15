namespace ManagementPortal.Web.ViewModels
{
  /// <summary>
  /// Product entity DTO
  /// </summary>
  public class ProductModel
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsArchived { get; set; }
    public bool IsTaxable { get; set; }
  }
}