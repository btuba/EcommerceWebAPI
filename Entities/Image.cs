using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("Color")]
        public int? ColorId { get; set; }
        public Color? Color { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }
    }
}
