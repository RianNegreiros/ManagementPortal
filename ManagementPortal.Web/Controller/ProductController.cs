using System.Linq;
using ManagementPortal.Data.Models;
using ManagementPortal.Services.Product;
using ManagementPortal.Web.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagementPortal.Web.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
      _logger = logger;
      _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
      _logger.LogInformation("Getting all Products");
      var products = _productService.GetProducts();

      var productViewModels = products
        .Select(ProductMapper.SerializeProductModel);

      return Ok(productViewModels);
    }
  }
}