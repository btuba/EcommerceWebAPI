using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddPaymentRequest
    {
        [Required(ErrorMessage = "Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required!")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Required!")]
        [CreditCard(ErrorMessage ="Validation error!")]
        public string Data { get; set; }
    }
}
