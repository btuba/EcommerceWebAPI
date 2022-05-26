using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SizeService : ISizeService
    {
        IMapper mapper;
        ISizeRepository sizeRepository;
        public SizeService(IMapper mapper, ISizeRepository sizeRepository)
        {
            this.mapper = mapper;
            this.sizeRepository = sizeRepository;
        }

        public async Task<int> AddSize(object request)
        {
            var size = mapper.Map<Size>(request);
            await sizeRepository.Create(size);
            return size.Id;
        }

        public async Task DeleteSize(int id)
        {
            await sizeRepository.Delete(id);
        }

        public async Task<SizeDisplayResponse> GetSizeById(int id)
        {
            var size = await sizeRepository.GetById(id);
            return mapper.Map<SizeDisplayResponse>(size);
        }

        public async Task<IList<SizeDisplayResponse>> GetSizes()
        {
            return mapper.Map<IList<SizeDisplayResponse>>(
                await sizeRepository.GetAll());
        }

        public async Task<IList<SizeDisplayResponse>> GetSizesByData(string data)
        {
            return mapper.Map<IList<SizeDisplayResponse>>(
                await sizeRepository.GetSizesByData(data));
        }

        public async Task<bool> IsSizeExist(int id)
        {
            return await sizeRepository.IsExist(id);
        }

        public async Task UpdateSize(object request)
        {
           // var response = mapper.Map<Size>(request);
            await sizeRepository.Update(mapper.Map<Size>(request));
        }
    }
}
