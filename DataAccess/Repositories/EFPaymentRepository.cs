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
    public class EFPaymentRepository : IPaymentRepository
    {
        ApiDbContext _context;
        public EFPaymentRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Payment entity)
        {
            _context.Payments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var payment = _context.Payments.FirstOrDefault(x => x.Id == id);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCustomer(int customerId)
        {
            return await _context.Payments.Where(x=> x.Customer.Id.Equals(customerId)).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Payments.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Payment entity)
        {
            _context.Payments.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
