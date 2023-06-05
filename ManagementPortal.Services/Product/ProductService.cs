using ManagementPortal.Data;
using ManagementPortal.Data.Models;

namespace ManagementPortal.Services.Product
{
  public class ProductService : IProductService
  {
    private readonly DataDbContext _context;
    public ProductService(DataDbContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Adds a new Product to the database
    /// </summary>
    /// <param name="product">Product object to be added to the database</param>
    /// <returns></returns>
    public ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product)
    {
      try
      {
        _context.Products.Add(product);

        var newInvetory = new ProductInventory
        {
          Product = product,
          QuantityOnHand = 0,
          IdealQuantity = 10,
        };

        _context.ProductInventories.Add(newInvetory);
        _context.SaveChanges();

        return new ServiceResponse<Data.Models.Product>
        {
          Time = DateTime.UtcNow,
          IsSuccess = true,
          Message = "New Product Added",
          Data = product
        };
      }

      catch (Exception e)
      {
        return new ServiceResponse<Data.Models.Product>
        {
          Time = DateTime.UtcNow,
          IsSuccess = false,
          Message = "Error Saving New Product",
          Data = product
        };
      }
    }

    /// <summary>
    /// Retrieves a Product from the database by Id
    /// </summary>
    /// <param name="id">Id of the Product to retrieve</param>
    /// <returns></returns>
    public Data.Models.Product GetProduct(int id)
    {
      return _context.Products.Find(id);
    }

    /// <summary>
    /// Retrieves all Products from the database
    /// </summary>
    /// <returns></returns>
    public List<Data.Models.Product> GetProducts()
    {
      return _context.Products.ToList();
    }


    /// <summary>
    /// Archives a Product by setting its IsArchived property to true
    /// </summary>
    /// <param name="id">Id of the Product to archive</param>
    /// <returns></returns>
    public ServiceResponse<Data.Models.Product> ArchiveProduct(int id)
    {
      try
      {
        var product = _context.Products.Find(id);
        product.IsArchived = true;
        _context.SaveChanges();

        return new ServiceResponse<Data.Models.Product>
        {
          Time = DateTime.UtcNow,
          IsSuccess = true,
          Message = $"Product {product.Id} Archived",
          Data = product
        };
      }

      catch (Exception e)
      {
        return new ServiceResponse<Data.Models.Product>
        {
          Time = DateTime.UtcNow,
          IsSuccess = false,
          Message = e.StackTrace,
          Data = null
        };
      }
    }
  }
}