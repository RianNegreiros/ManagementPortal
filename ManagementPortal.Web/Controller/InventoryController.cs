using ManagementPortal.Services.Inventory;
using ManagementPortal.Web.Serialization;
using ManagementPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPortal.Web.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class InventoryController : ControllerBase
  {
    private readonly IInventoryService _inventoryService;
    private readonly ILogger<InventoryController> _logger;

    public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
    {
      _logger = logger;
      _inventoryService = inventoryService;
    }

    [HttpGet]
    public IActionResult GetCurrentInventory()
    {
      _logger.LogInformation("Getting all Inventory");
      var inventory = _inventoryService.GetInventory()
          .Select(pi => new ProductInventoryModel
          {
            Id = pi.Id,
            Product = ProductMapper.SerializeProductModel(pi.Product),
            IdealQuantity = pi.IdealQuantity,
            QuantityOnHand = pi.QuantityOnHand
          })
          .OrderBy(inv => inv.Product.Name)
          .ToList();

      return Ok(inventory);
    }

    [HttpPatch]
    public IActionResult UpdateInventory([FromBody] ShipmentModel shipment)
    {
      _logger.LogInformation($"Updating Inventory for {shipment.ProductId} - Adjustment: {shipment.Adjustment}");
      var id = shipment.ProductId;
      var adjustment = shipment.Adjustment;
      var inventory = _inventoryService.UpdateUnitsAvailable(id, adjustment);
      return Ok(inventory);
    }
  }
}