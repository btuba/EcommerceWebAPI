using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }
}
