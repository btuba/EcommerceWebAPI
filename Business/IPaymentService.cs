using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IPaymentService
    {
        Task<IList<PaymentDisplayResponse>> GetPaymentsByCustomer(int customerId);
        Task<int> AddPaymentMethod(object request);
        Task UpdatePayment(object request);
        Task DeletePayment(int id);
        Task<PaymentDisplayResponse> GetPaymentById(int id);
        Task<IList<PaymentDisplayResponse>> GetAll();
        Task<bool> IsPaymentExist(int id);
    }
}
