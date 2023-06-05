namespace ManagementPortal.Data.Models
{
  public class Customer : BaseModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public CustomerAddress Address { get; set; }
  }
}