using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ISizeService
    {
        Task<IList<SizeDisplayResponse>> GetSizesByData(string data);
        Task AddSize(object request);
        Task UpdateSize(object request);
        Task DeleteSize(int id);
        Task<SizeDisplayResponse> GetSizeById(int id);
        Task<IList<SizeDisplayResponse>> GetSizes();
        Task<bool> IsSizeExist(int id);
    }
}
