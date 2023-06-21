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

    public InventoryController(
        ILogger<InventoryController> logger,
        IInventoryService inventoryService
    )
    {
      _inventoryService = inventoryService;
      _logger = logger;
    }

    [HttpGet("/api/inventory")]
    public ActionResult GetCurrentInventory()
    {
      _logger.LogInformation("Getting all inventory...");

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

    [HttpPatch("/api/inventory")]
    public ActionResult UpdateInventory([FromBody] ShipmentModel shipment)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var id = shipment.ProductId;
      var adjustment = shipment.Adjustment;
      var inventory = _inventoryService.UpdateUnitsAvailable(id, adjustment);
      return Ok(inventory);
    }
  }
}