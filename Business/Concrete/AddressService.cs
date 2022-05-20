using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressService : IAddressService
    {
        IMapper _mapper;
        IAddressRepository _addressRepository;
        public AddressService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<int> AddAddress(object request)
        {
            var address = _mapper.Map<Address>(request);
            await _addressRepository.Create(address);
            return address.Id;
        }

        public async Task DeleteAddress(int id)
        {
            await _addressRepository.Delete(id);
        }

        public async Task<AddressDisplayResponse> GetAddressById(int id)
        {
            var address = await _addressRepository.GetById(id);
            var response = _mapper.Map<AddressDisplayResponse>(address);
            return response;
        }

        public async Task<IList<AddressDisplayResponse>> GetAddresses()
        {
            var addresses = await _addressRepository.GetAll();
            var response = _mapper.Map<IList<AddressDisplayResponse>>(addresses);
            return response;
        }

        public async Task<IList<AddressDisplayResponse>> GetAddressesByCity(string city)
        {
            var addresses = await _addressRepository.GetAddressesByCity(city);
            var response = _mapper.Map<IList<AddressDisplayResponse>>(addresses);
            return response;
        }

        public async Task<bool> IsAddressExist(int id)
        {
            return await _addressRepository.IsExist(id);
        }

        public async Task UpdateAddress(object request)
        {
            var address = _mapper.Map<Address>(request);
            await _addressRepository.Update(address);
        }
    }
}
