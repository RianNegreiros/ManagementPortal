namespace ManagementPortal.Services.Customer
{
  public interface ICustomerService
  {
    public List<Data.Models.Customer> GetCustomers();
    public ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer);
    public ServiceResponse<bool> DeleteCustomer(int id);
    public Data.Models.Customer GetById(int id);
  }
}