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
    public class EFSizeRepository : ISizeRepository
    {

        ApiDbContext _context;
        public EFSizeRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Size entity)
        {
            _context.Sizes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var size = _context.Sizes.FirstOrDefault(x => x.Id == id);
            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Size>> GetAll()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> GetById(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }

        public async Task<IEnumerable<Size>> GetSizesByData(string data)
        {
            return await _context.Sizes.Where(x => x.Data == data).ToListAsync();
        }

        public async Task<IEnumerable<Size>> GetSizesByProduct(Product product)
        {
            return await _context.Sizes.Where(x => x.Products.Contains(product)).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Sizes.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Size entity)
        {
            _context.Sizes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
