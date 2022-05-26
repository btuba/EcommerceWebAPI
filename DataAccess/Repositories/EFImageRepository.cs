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
    public class EFImageRepository : IImageRepository
    {
        ApiDbContext _context;
        public EFImageRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Image entity)
        {
            _context.Images.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == id);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetById(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<IEnumerable<Image>> GetImagesByColor(int colorId)
        {
            return await _context.Images.Where(x => x.Color.Id == colorId).ToListAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesByProduct(int productId)
        {
            return await _context.Images.Where(x => x.Product.Id == productId).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Images.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Image entity)
        {
            _context.Images.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
