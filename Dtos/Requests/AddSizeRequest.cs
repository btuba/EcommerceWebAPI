using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddSizeRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Data { get; set; }
        public int ProductId { get; set; }
    }
}
