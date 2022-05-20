using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddOrderRequest
    {
        public int CustomerId { get; set; }
        public ICollection<int> ProductsId { get; set; }
        public int PaymentId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}
