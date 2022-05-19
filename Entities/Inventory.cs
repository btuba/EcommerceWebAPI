using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Inventory : IEntity 
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public int Quantity { get; set; }
    }
}
