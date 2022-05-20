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
    public class EFProductRepository : IProductRepository
    {
        ApiDbContext _context;
        public EFProductRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task Create(Product entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetActiveProducts()
        {
            return await _context.Products.Where(p => p.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByColor(int colorId)
        {
            var color = _context.Colors.FirstOrDefault(x => x.Id == colorId);
            return await _context.Products.Where(p => p.Colors.Contains(color)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCreatedDate(DateTime time)
        {
            return await _context.Products.Where(p => p.CreatedAt == time).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySize(int sizeId)
        {
            var size = _context.Sizes.FirstOrDefault(x => x.Id == sizeId);
            return await _context.Products.Where(p => p.Sizes.Contains(size)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByUpdatedDate(DateTime time)
        {
            return await _context.Products.Where(p => p.UpdatedAt == time).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetUnactiveProducts()
        {
            return await _context.Products.Where(p => p.IsActive == false).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task Update(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
