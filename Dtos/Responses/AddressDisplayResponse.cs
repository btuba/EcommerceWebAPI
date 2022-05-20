using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class AddressDisplayResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Detail { get; set; }
        public Customer? Customer { get; set; }
    }
}
