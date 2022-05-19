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
    public class EFCustomerRepository : ICustomerRepository
    {
        ApiDbContext _context;
        public EFCustomerRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Customer entity)
        {
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x=> x.Id == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersByName(string name)
        {
            return await _context.Customers.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Customers.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Customer entity)
        {
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
