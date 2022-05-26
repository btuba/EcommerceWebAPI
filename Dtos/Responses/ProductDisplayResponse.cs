using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class ProductDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<ImageDisplayResponse> Images { get; set; }
        public ICollection<SizeDisplayResponse> Sizes { get; set; }
        public int? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
