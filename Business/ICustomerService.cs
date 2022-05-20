using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(object request);
        Task UpdateCustomer(object request);
        Task DeleteCustomer(int id);
        Task<CustomerDisplayResponse> GetCustomerById(int id);
        Task<IList<CustomerListResponse>> GetCustomers();
        Task<bool> IsCustomerExist(int id);
    }
}
