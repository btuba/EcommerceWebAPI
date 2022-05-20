using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IColorService
    {
        Task<IList<ColorDisplayResponse>> GetColorsByName(string name);
        Task<int> AddColor(object request);
        Task UpdateColor(object request);
        Task DeleteColor(int id);
        Task<ColorDisplayResponse> GetColorById(int id);
        Task<IList<ColorDisplayResponse>> GetColors();
        Task<bool> IsColorExist(int id);
    }
}
