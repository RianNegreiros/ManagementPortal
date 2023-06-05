using System.ComponentModel.DataAnnotations;

namespace ManagementPortal.Data.Models
{
  public class CustomerAddress
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    [MaxLength(100)]
    public string AddressLine1 { get; set; }

    [MaxLength(100)]
    public string AddressLine2 { get; set; }

    [MaxLength(100)]
    public string City { get; set; }

    [MaxLength(2)]
    public string StateProvince { get; set; }

    [MaxLength(10)]
    public string PostalCode { get; set; }

    [MaxLength(50)]
    public string Country { get; set; }
  }
}