using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageService : IImageService
    {
        IMapper mapper;
        IImageRepository imageRepository;
        public ImageService(IMapper mapper, IImageRepository imageRepository)
        {
            this.mapper = mapper;
            this.imageRepository = imageRepository;
        }

        public async Task<int> AddImage(object request)
        {
            var image = mapper.Map<Image>(request);
            await imageRepository.Create(image);
            return image.Id;
        }

        public async Task DeleteImage(int id)
        {
            await imageRepository.Delete(id);
        }

        public async Task<ImageDisplayResponse> GetImageById(int id)
        {
            return mapper.Map<ImageDisplayResponse>(
                await imageRepository.GetById(id));
        }

        public async Task<IList<ImageDisplayResponse>> GetImages()
        {
            return mapper.Map<IList<ImageDisplayResponse>>(
                await imageRepository.GetAll());
        }

        public async Task<IList<ImageDisplayResponse>> GetImagesByColor(int colorId)
        {
            return mapper.Map<IList<ImageDisplayResponse>>(
                await imageRepository.GetImagesByColor(colorId));
        }

        public async Task<bool> IsImageExist(int id)
        {
            return await imageRepository.IsExist(id);
        }

        public async Task UpdateImage(object request)
        {
            await imageRepository.Update(
                mapper.Map<Image>(request));
        }
    }
}
