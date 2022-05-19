using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> GetInventoriesBySize(int sizeId);
        Task<IEnumerable<Inventory>> GetInvevtoriesByColor(int colorId);
        Task<IEnumerable<Inventory>> GetInvevtoriesByProduct(int productId);
    }
}
