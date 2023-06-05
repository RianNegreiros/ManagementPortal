using ManagementPortal.Services.Customer;
using ManagementPortal.Web.Serialization;
using ManagementPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPortal.Web.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
      _logger = logger;
      _customerService = customerService;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
      _logger.LogInformation("Getting all Customers");
      var customers = _customerService.GetCustomers();

      var customerModels = customers
          .Select(customer => new CustomerModel
          {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = CustomerMapper
                  .MapCustomerAddress(customer.Address),
            Created = customer.Created,
            Updated = customer.Updated
          })
          .OrderByDescending(customer => customer.Created)
          .ToList();

      return Ok(customers);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
      _logger.LogInformation("Deleting Customer");
      var response = _customerService.DeleteCustomer(id);

      return Ok(response);
    }
  }
}