using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        IMapper mapper;
        ICustomerRepository customerRepository;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }

        public async Task<int> AddCustomer(object request)
        {
            var customer = mapper.Map<Customer>(request);
            await customerRepository.Create(customer);
            return customer.Id;
        }

        public async Task DeleteCustomer(int id)
        {
            await customerRepository.Delete(id);
        }

        public async Task<CustomerDisplayResponse> GetCustomerById(int id)
        {
            return mapper.Map<CustomerDisplayResponse>(
                await customerRepository.GetById(id));
        }

        public async Task<IList<CustomerListResponse>> GetCustomers()
        {
            return mapper.Map<IList<CustomerListResponse>>(
                await customerRepository.GetAll());
        }

        public async Task<bool> IsCustomerExist(int id)
        {
            return await customerRepository.IsExist(id);
        }

        public async Task UpdateCustomer(object request)
        {
            await customerRepository.Update(
                mapper.Map<Customer>(request));
        }
    }
}
