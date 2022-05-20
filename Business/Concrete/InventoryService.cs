using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InventoryService : IInventoryService
    {
        IMapper mapper;
        IInventoryRepository inventoryRepository;
        public InventoryService(IMapper mapper, IInventoryRepository inventoryRepository)
        {
            this.mapper = mapper;
            this.inventoryRepository = inventoryRepository;
        }

        public async Task<int> AddInventory(object request)
        {
            var inventory = mapper.Map<Inventory>(request);
            await inventoryRepository.Create(inventory);
            return inventory.Id;
        }

        public async Task DeleteInventory(int id)
        {
            await inventoryRepository.Delete(id);
        }

        public async Task<IList<InventoryDisplayResponse>> GetInventories()
        {
            return mapper.Map<IList<InventoryDisplayResponse>>(
                await inventoryRepository.GetAll());
        }

        public async Task<IList<InventoryDisplayResponse>> GetInventoriesBySize(int sizeId)
        {
            return mapper.Map<IList<InventoryDisplayResponse>>(
                await inventoryRepository.GetInventoriesBySize(sizeId));
        }

        public async Task<InventoryDisplayResponse> GetInventoryById(int id)
        {
            return mapper.Map<InventoryDisplayResponse>(
                await inventoryRepository.GetById(id));
        }

        public async Task<IList<InventoryDisplayResponse>> GetInvevtoriesByColor(int colorId)
        {
            return mapper.Map<IList<InventoryDisplayResponse>>(
                await inventoryRepository.GetInvevtoriesByColor(colorId));
        }

        public async Task<IList<InventoryDisplayResponse>> GetInvevtoriesByProduct(int productId)
        {
            return mapper.Map<IList<InventoryDisplayResponse>>(
                await inventoryRepository.GetInvevtoriesByProduct(productId));
        }

        public async Task<bool> IsInventoryExist(int id)
        {
            return await inventoryRepository.IsExist(id);
        }

        public async Task UpdateInventory(object request)
        {
            await inventoryRepository.Update(
                mapper.Map<Inventory>(request));
        }
    }
}
