using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<IEnumerable<Image>> GetImagesByColor(int colorId);
        Task<IEnumerable<Image>> GetImagesByProduct(int productId);
    }
}
