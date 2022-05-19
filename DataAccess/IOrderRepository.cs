using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(Customer customer);
        Task<IEnumerable<Order>> GetOrdersByProduct(Product product);
        Task<IEnumerable<Order>> GetOrdersByPaymentMethod(Payment payment);
        Task<IEnumerable<Order>> GetApprovedOrders();
        Task<IEnumerable<Order>> GetUnapprovedOrders();
        Task<IEnumerable<Order>> GetCompletedOrders();
        Task<IEnumerable<Order>> GetUncompletedOrders();
        Task<IEnumerable<Order>> GetOrdersByCreatedDate(DateTime time);
        Task<IEnumerable<Order>> GetOrdersByUpdatedDate(DateTime time);
        Task<IEnumerable<Order>> GetOrdersByTotal(decimal total);
    }
}
