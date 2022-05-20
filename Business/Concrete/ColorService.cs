using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorService : IColorService
    {
        IMapper mapper;
        IColorRepository colorRepository;

        public ColorService(IMapper mapper, IColorRepository colorRepository)
        {
            this.mapper = mapper;
            this.colorRepository = colorRepository;
        }

        public async Task<int> AddColor(object request)
        {
            var color = mapper.Map<Color>(request);
            await colorRepository.Create(color);
            return color.Id;
        }

        public async Task DeleteColor(int id)
        {
            await colorRepository.Delete(id);
        }

        public async Task<ColorDisplayResponse> GetColorById(int id)
        {
            return mapper.Map<ColorDisplayResponse>(
                await colorRepository.GetById(id));
        }

        public async Task<IList<ColorDisplayResponse>> GetColors()
        {
            return mapper.Map<IList<ColorDisplayResponse>>(
                await colorRepository.GetAll());
        }

        public async Task<IList<ColorDisplayResponse>> GetColorsByName(string name)
        {
            return mapper.Map<IList<ColorDisplayResponse>>(
                await colorRepository.GetColorsByName(name));
        }

        public async Task<bool> IsColorExist(int id)
        {
            return await colorRepository.IsExist(id);
        }

        public async Task UpdateColor(object request)
        {
            await colorRepository.Update(
                mapper.Map<Color>(request));
        }
    }
}
