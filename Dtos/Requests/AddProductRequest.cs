using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddProductRequest
    {
        [Required(ErrorMessage = "Required!")]
        [StringLength(50, ErrorMessage = "Max 50 character!")]
        [MinLength(3, ErrorMessage = "Min 3 character!")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public bool IsActive { get; set; }
        [Url(ErrorMessage = "Validation error!")]
        public string? Url { get; set; }
    }
}
