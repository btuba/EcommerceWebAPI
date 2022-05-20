using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class CategoryDisplayResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SupCategoryId { get; set; }
    }
}
