using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IAddressService
    {
        Task<IList<AddressDisplayResponse>> GetAddressesByCity(string city);
        Task<int> AddAddress(object request);
        Task UpdateAddress(object request);
        Task DeleteAddress(int id);
        Task<AddressDisplayResponse> GetAddressById(int id);
        Task<IList<AddressDisplayResponse>> GetAddresses();
        Task<bool> IsAddressExist(int id);
    }
}
