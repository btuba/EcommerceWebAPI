using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsBySize(int sizeId);
        Task<IEnumerable<Product>> GetProductsByColor(int colorId);
        Task<IEnumerable<Product>> GetProductsByCreatedDate(DateTime time);
        Task<IEnumerable<Product>> GetProductsByUpdatedDate(DateTime time);
        Task<IEnumerable<Product>> GetActiveProducts();
        Task<IEnumerable<Product>> GetUnactiveProducts();
    }
}
