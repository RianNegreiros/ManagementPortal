using ManagementPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagementPortal.Services.Customer
{
  public class CustomerService : ICustomerService
  {
    private readonly DataDbContext _context;
    public CustomerService(DataDbContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Adds a new customer to the database
    /// </summary>
    /// <param name="customer">Customer object to be added</param>
    /// <returns></returns>
    public ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer)
    {
      try
      {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return new ServiceResponse<Data.Models.Customer>
        {
          Data = customer,
          Time = DateTime.UtcNow,
          Message = "Saved new customer",
          IsSuccess = true
        };
      }

      catch (Exception e)
      {
        return new ServiceResponse<Data.Models.Customer>
        {
          Data = customer,
          Time = DateTime.UtcNow,
          Message = e.StackTrace,
          IsSuccess = false
        };
      }
    }

    /// <summary>
    /// Deletes a customer from the database
    /// </summary>
    /// <param name="id">Id of the customer to delete</param>
    /// <returns></returns>
    public ServiceResponse<bool> DeleteCustomer(int id)
    {
      var customer = _context.Customers.Find(id);
      var now = DateTime.UtcNow;

      if (customer == null)
      {
        return new ServiceResponse<bool>
        {
          Data = false,
          Time = now,
          Message = "Customer to delete not found",
          IsSuccess = false
        };
      }

      try
      {
        _context.Customers.Remove(customer);
        _context.SaveChanges();

        return new ServiceResponse<bool>
        {
          Data = true,
          Time = now,
          Message = "Customer deleted",
          IsSuccess = true
        };
      }

      catch (Exception e)
      {
        return new ServiceResponse<bool>
        {
          Data = false,
          Time = now,
          Message = e.StackTrace,
          IsSuccess = false
        };
      }
    }

    /// <summary>
    /// Returns a customer by id
    /// </summary>
    /// <param name="id">Id of the customer to return</param>
    /// <returns></returns>
    public Data.Models.Customer GetById(int id)
    {
      return _context.Customers.Find(id);
    }

    /// <summary>
    /// Returns all customers from the database
    /// </summary>
    /// <returns></returns>
    public List<Data.Models.Customer> GetCustomers()
    {
      return _context.Customers
        .Include(customer => customer.Address)
        .OrderBy(customer => customer.LastName)
        .ToList();
    }
  }
}