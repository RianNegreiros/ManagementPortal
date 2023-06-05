using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPortal.Data.Models;
using ManagementPortal.Web.ViewModels;

namespace ManagementPortal.Web.Serialization
{
  /// <summary>
  ///
  /// </summary>
  /// params
  /// <returns></returns>
  public static class OrderMapper
  {
    public static SalesOrder SerializeInvoiceToOrder(InvoiceModel invoice)
    {
      var salesOrderItems = invoice.LineItems
          .Select(item => new SalesOrderItem
          {
            Id = item.Id,
            Quantity = item.Quantity,
            Product = ProductMapper.SerializeProductModel(item.Product)
          }).ToList();

      return new SalesOrder
      {
        SalesOrderItems = salesOrderItems,
        Created = invoice.Created,
        Updated = invoice.Updated,
      };
    }

    public static List<OrderModel> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
    {
      return orders.Select(order => new OrderModel
      {
        Id = order.Id,
        Created = order.Created,
        Updated = order.Updated,
        LineItems = SerializeSalesOrderItems(order.SalesOrderItems),
        Customer = CustomerMapper.SerializeCustomerModel(order.Customer),
        IsPaid = order.IsPaid
      }).ToList();
    }

    private static List<SalesOrderItemModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
    {
      return orderItems.Select(item => new SalesOrderItemModel
      {
        Id = item.Id,
        Quantity = item.Quantity,
        Product = ProductMapper.SerializeProductModel(item.Product)
      }).ToList();
    }
  }
}