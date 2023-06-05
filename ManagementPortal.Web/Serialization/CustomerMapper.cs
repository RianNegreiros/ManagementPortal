using ManagementPortal.Data.Models;
using ManagementPortal.Web.ViewModels;

namespace ManagementPortal.Web.Serialization
{
  public static class CustomerMapper
  {
    /// <summary>
    ///
    /// </summary>
    /// params
    /// <returns></returns>
    public static CustomerModel SerializeCustomerModel(Customer customer)
    {
      var address = new CustomerAddressModel
      {
        Id = customer.Address.Id,
        Created = customer.Address.Created,
        Updated = customer.Address.Updated,
        AddressLine1 = customer.Address.AddressLine1,
        AddressLine2 = customer.Address.AddressLine2,
        City = customer.Address.City,
        State = customer.Address.StateProvince,
        PostalCode = customer.Address.PostalCode,
        Country = customer.Address.Country
      };

      return new CustomerModel
      {
        Id = customer.Id,
        Created = customer.Created,
        Updated = customer.Updated,
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        Address = address
      };
    }

    /// <summary>
    ///
    /// </summary>
    /// params
    /// <returns></returns>
    public static CustomerAddressModel MapCustomerAddress(CustomerAddress address)
    {
      return new CustomerAddressModel
      {
        Id = address.Id,
        AddressLine1 = address.AddressLine1,
        AddressLine2 = address.AddressLine2,
        City = address.City,
        State = address.StateProvince,
        PostalCode = address.PostalCode,
        Country = address.Country,
        Created = DateTime.UtcNow,
        Updated = DateTime.UtcNow
      };
    }

    /// <summary>
    ///
    /// </summary>
    /// params
    /// <returns></returns>
    public static CustomerAddress MapCustomerAddress(CustomerAddressModel address)
    {
      return new CustomerAddress
      {
        AddressLine1 = address.AddressLine1,
        AddressLine2 = address.AddressLine2,
        City = address.City,
        StateProvince = address.State,
        PostalCode = address.PostalCode,
        Country = address.Country,
        Created = DateTime.UtcNow,
        Updated = DateTime.UtcNow
      };
    }
  }
}