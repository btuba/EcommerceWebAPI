using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public Color Color { get; set; }
        public string Url { get; set; }
    }
}
