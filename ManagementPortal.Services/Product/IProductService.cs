namespace ManagementPortal.Services.Product
{
  public interface IProductService
  {
    List<Data.Models.Product> GetProducts();
    Data.Models.Product GetProduct(int id);
    ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product);
    ServiceResponse<Data.Models.Product> ArchiveProduct(int id);
  }
}