using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddAddressRequest
    {
        [Required(ErrorMessage = "Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Required!")]
        public int CustomerId { get; set; }
    }
}
