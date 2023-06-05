using ManagementPortal.Data.Models;

namespace ManagementPortal.Services.Order
{
  public interface IOrderService
  {
    List<SalesOrder> GetOrders();
    ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder order);
    ServiceResponse<bool> MarkFulfilled(int id);
  }
}