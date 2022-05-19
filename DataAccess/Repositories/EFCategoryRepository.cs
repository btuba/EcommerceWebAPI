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
    public class EFCategoryRepository : ICategoryRepository
    {
        ApiDbContext _context;
        public EFCategoryRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Category entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category =  _context.Categories.FirstOrDefault(x=> x.Id == id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByName(string name)
        {
            return await _context.Categories.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Categories.AnyAsync(x=> x.Id == id);
        }

        public async Task Update(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
