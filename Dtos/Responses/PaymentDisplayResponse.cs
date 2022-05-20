using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class PaymentDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Customer { get; set; }
        public string Data { get; set; }
    }
}
