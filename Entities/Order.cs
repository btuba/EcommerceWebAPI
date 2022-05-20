using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
        public Payment Payment { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsCompleted{ get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; } 
    }
}
