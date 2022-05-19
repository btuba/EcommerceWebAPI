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
        Task<IEnumerable<Product>> GetProductsBySize(Size size);
        Task<IEnumerable<Product>> GetProductsByColor(Color color);
        Task<IEnumerable<Product>> GetProductsByCreatedDate(DateTime time);
        Task<IEnumerable<Product>> GetProductsByUpdatedDate(DateTime time);
        Task<IEnumerable<Product>> GetActiveProdycts();
        Task<IEnumerable<Product>> GetUnactiveProdycts();
    }
}
