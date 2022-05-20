using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IInventoryService
    {
        Task<int> AddInventory(object request);
        Task UpdateInventory(object request);
        Task DeleteInventory(int id);
        Task<InventoryDisplayResponse> GetInventoryById(int id);
        Task<IList<InventoryDisplayResponse>> GetInventories();
        Task<bool> IsInventoryExist(int id);
        Task<IList<InventoryDisplayResponse>> GetInventoriesBySize(int sizeId);
        Task<IList<InventoryDisplayResponse>> GetInvevtoriesByColor(int colorId);
        Task<IList<InventoryDisplayResponse>> GetInvevtoriesByProduct(int productId);
    }
}
