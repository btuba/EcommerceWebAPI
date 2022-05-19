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
    public class EFInventoryRepository : IInventoryRepository
    {
        ApiDbContext _context;
        public EFInventoryRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Inventory entity)
        {
            _context.Inventories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var inventory = _context.Inventories.FirstOrDefault(x => x.Id == id);
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetById(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesBySize(int sizeId)
        {
            return await _context.Inventories.Where(x => x.SizeId == sizeId).ToListAsync();
        }

        public async Task<IEnumerable<Inventory>> GetInvevtoriesByColor(int colorId)
        {
            return await _context.Inventories.Where(x => x.ColorId == colorId).ToListAsync();
        }

        public async Task<IEnumerable<Inventory>> GetInvevtoriesByProduct(int productId)
        {
            return await _context.Inventories.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Inventories.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Inventory entity)
        {
            _context.Inventories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
