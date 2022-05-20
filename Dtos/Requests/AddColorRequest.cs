using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddColorRequest
    {
        [Required(ErrorMessage = "Required!")]
        public string Name { get; set; }
    }
}
