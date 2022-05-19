using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Size : IEntity
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public ICollection<Product> Products { get; set; }
        public Inventory Inventory { get; set; }
    }
}
