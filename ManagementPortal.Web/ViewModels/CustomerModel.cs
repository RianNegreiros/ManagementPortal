using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ManagementPortal.Data.Models;

namespace ManagementPortal.Web.ViewModels
{
  public class CustomerModel
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    [MaxLength(32)]
    public string FirstName { get; set; }
    [MaxLength(32)]
    public string LastName { get; set; }
    public CustomerAddressModel Address { get; set; }
  }

  public class CustomerAddressModel
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
  }
}