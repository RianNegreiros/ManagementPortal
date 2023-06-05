namespace ManagementPortal.Data.Models
{
  public class BaseModel
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
  }
}