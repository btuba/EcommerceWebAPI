using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class UpdateSizeResponse
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int ProductId { get; set; }
    }
}
