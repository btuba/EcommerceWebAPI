using DataAccess.Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        ApiDbContext _context;
        public EFOrderRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Order entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetApprovedOrders()
        {
            return await _context.Orders.Where(x=> x.IsApproved == true).ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetCompletedOrders()
        {
            return await _context.Orders.Where(x => x.IsCompleted == true).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCreatedDate(DateTime time)
        {
            return await _context.Orders.Where(x => x.CreatedAt == time).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
        {
            return await _context.Orders.Where(x => x.Customer.Id == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByPaymentMethod(int paymentId)
        {
            return await _context.Orders.Where(x => x.Payment.Id == paymentId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByProduct(Product product)
        {
            return await _context.Orders.Where(x => x.Products.Contains(product)).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByTotal(decimal total)
        {
            return await _context.Orders.Where(x => x.Total == total).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUpdatedDate(DateTime time)
        {
            return await _context.Orders.Where(x => x.UpdatedAt == time).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetUnapprovedOrders()
        {
            return await _context.Orders.Where(x => x.IsApproved == false).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetUncompletedOrders()
        {
            return await _context.Orders.Where(x => x.IsCompleted == false).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Orders.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
