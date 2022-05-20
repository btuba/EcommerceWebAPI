using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class CustomerDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<object> Addresses { get; set; }
        public ICollection<object> Payments { get; set; }
        public ICollection<object> Orders { get; set; }
    }
}
