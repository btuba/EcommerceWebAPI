using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
