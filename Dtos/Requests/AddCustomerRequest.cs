using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddCustomerRequest
    {
        [Required(ErrorMessage = "Required!")]
        [StringLength(50, ErrorMessage = "Max 50 character!")]
        [MinLength(3, ErrorMessage = "Min 3 character!")]
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required(ErrorMessage = "Required!")]
        [EmailAddress(ErrorMessage ="Validation error!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Phone(ErrorMessage ="Validation error!")]
        public string Phone { get; set; }
    }
}
