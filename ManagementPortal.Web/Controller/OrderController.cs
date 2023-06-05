using ManagementPortal.Services.Customer;
using ManagementPortal.Services.Order;
using ManagementPortal.Web.Serialization;
using ManagementPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPortal.Web.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrderController : ControllerBase
  {
    private readonly IOrderService _orderService;
    private readonly ICustomerService _customerService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderService orderService, ICustomerService customerService, ILogger<OrderController> logger)
    {
      _orderService = orderService;
      _customerService = customerService;
      _logger = logger;
    }

    [HttpPost("invoice")]
    public IActionResult GenerateNewInvoice([FromBody] InvoiceModel invoice)
    {
      _logger.LogInformation("Generating Invoice");
      var order = OrderMapper.SerializeInvoiceToOrder(invoice);
      order.Customer = _customerService.GetById(invoice.CustomerId);
      _orderService.GenerateInvoiceForOrder(order);

      return Ok();
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
      _logger.LogInformation("Getting all Orders");
      var orders = _orderService.GetOrders();

      var orderModels = OrderMapper.SerializeOrdersToViewModels(orders);

      return Ok(orderModels);
    }

    [HttpPatch("complete/{id}")]
    public IActionResult MarkOrderComplete(int id)
    {
      _logger.LogInformation("Marking Order Complete");
      var response = _orderService.MarkFulfilled(id);

      return Ok(response);
    }
  }
}