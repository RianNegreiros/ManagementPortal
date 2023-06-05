using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPortal.Web.ViewModels;

namespace ManagementPortal.Web.Serialization
{
  public class ProductMapper
  {
    /// <summary>
    ///
    /// </summary>
    /// params 
    public static ProductModel SerializeProductModel(Data.Models.Product product)
    {
      return new ProductModel
      {
        Id = product.Id,
        Created = product.Created,
        Updated = product.Updated,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        IsArchived = product.IsArchived,
        IsTaxable = product.IsTaxable
      };
    }

    public static Data.Models.Product SerializeProductModel(ProductModel product)
    {
      return new Data.Models.Product
      {
        Id = product.Id,
        Created = product.Created,
        Updated = product.Updated,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        IsArchived = product.IsArchived,
        IsTaxable = product.IsTaxable
      };
    }
  }
}