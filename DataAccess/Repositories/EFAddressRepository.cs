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
    public class EFAddressRepository : IAddressRepository
    {
        ApiDbContext _context;
        public EFAddressRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task Create(Address entity)
        {
            _context.Addresss.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var address = _context.Addresss.FirstOrDefault(a => a.Id == id);
            _context.Addresss.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAddressesByCity(string city)
        {
            return await _context.Addresss.Where(a => a.City == city).ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _context.Addresss.ToListAsync();
        }

        public async Task<Address> GetById(int id)
        {
            return await _context.Addresss.FindAsync(id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Addresss.AnyAsync(a => a.Id == id);
        }

        public async Task Update(Address entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
