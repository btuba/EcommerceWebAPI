using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentService : IPaymentService
    {
        IMapper mapper;
        IPaymentRepository paymentRepository;
        public PaymentService(IMapper mapper, IPaymentRepository repository)
        {
            this.mapper = mapper;
            this.paymentRepository = repository;
        }

        public async Task<int> AddPaymentMethod(object request)
        {
            var payment = mapper.Map<Payment>(request);
            await paymentRepository.Create(payment);
            return payment.Id;
        }

        public async Task DeletePayment(int id)
        {
            await paymentRepository.Delete(id);
        }

        public async Task<IList<PaymentDisplayResponse>> GetAll()
        {
            return mapper.Map<IList<PaymentDisplayResponse>>(await paymentRepository.GetAll());
        }

        public async Task<PaymentDisplayResponse> GetPaymentById(int id)
        {
            return mapper.Map<PaymentDisplayResponse>(
                await paymentRepository.GetById(id));
        }

        public async Task<IList<PaymentDisplayResponse>> GetPaymentsByCustomer(int customerId)
        {
            return mapper.Map<IList<PaymentDisplayResponse>>(
                await paymentRepository.GetPaymentsByCustomer(customerId));
        }

        public async Task<bool> IsPaymentExist(int id)
        {
            return await paymentRepository.IsExist(id);
        }

        public async Task UpdatePayment(object request)
        {
            await paymentRepository.Update(mapper.Map<Payment>(request));
        }
    }
}
