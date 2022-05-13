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
        //[ForeignKey("Product")]
        //public int ProductId { get; set; }
        //public Product Product { get; set; }
        //[ForeignKey("Size")]
        //public int SizeId { get; set; }
        //public Size Size { get; set; }
        //[ForeignKey("Color")]
        //public int ColorId { get; set; }
        //public Color Color { get; set; }
        //public int Quantity { get; set; } = 0;
    }
}
