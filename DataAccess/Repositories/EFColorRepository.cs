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
    public class EFColorRepository : IColorRepository
    {
        ApiDbContext _context;
        public EFColorRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Color entity)
        {
            _context.Colors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var color = _context.Colors.FirstOrDefault(x => x.Id == id);
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Color>> GetAll()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<Color> GetById(int id)
        {
            return await _context.Colors.FindAsync(id);
        }

        public async Task<IEnumerable<Color>> GetColorsByName(string name)
        {
            return await _context.Colors.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Colors.AnyAsync(x => x.Id == id);
        }

        public async Task Update(Color entity)
        {
            _context.Colors.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
