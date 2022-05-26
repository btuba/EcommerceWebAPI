using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductService
    {
        Task<ProductDisplayResponse> GetProduct(int id);
        Task<IList<ProductCardDisplayResponse>> GetProducts();
        Task<IList<ProductCardDisplayResponse>> GetProductByName(string key);
        Task<IList<ProductCardDisplayResponse>> GetProductBySize(int sizeId);
        Task<IList<ProductCardDisplayResponse>> GetProductByColor(int colorId);
        Task<IList<ProductCardDisplayResponse>> GetProductByCreatedDate(DateTime time);
        Task<IList<ProductCardDisplayResponse>> GetProductByUpdatedDate(DateTime time);
        Task<IList<ProductCardDisplayResponse>> GetActiveProducts();
        Task<IList<ProductCardDisplayResponse>> GetUnactiveProducts();
        Task<int> AddProduct(object request);
        Task UpdateProduct(object request);
        Task DeleteProduct(int id);
        Task<bool> IsProductExist(int id);
        Task<int> AddSizeToProduct(int sizeId, int productId);
    }
}
