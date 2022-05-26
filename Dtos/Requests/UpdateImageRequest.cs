using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class UpdateImageRequest
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public string Url { get; set; }
    }
}
