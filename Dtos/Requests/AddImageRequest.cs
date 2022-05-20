using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddImageRequest
    {
        public int? ColorId { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Url(ErrorMessage ="Validation error!")]
        public string Url { get; set; }
    }
}
