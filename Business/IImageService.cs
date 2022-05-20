using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IImageService
    {
        Task AddImage(object request);
        Task UpdateImage(object request);
        Task DeleteImage(object request);
        Task<ImageDisplayResponse> GetImageById(int id);
        Task<IList<ImageDisplayResponse>> GetImages();
        Task<bool> IsImageExist(int id);
        Task<IList<ImageDisplayResponse>> GetImagesByColor(int colorId);
    }
}
