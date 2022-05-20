using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByCity(string city);
    }
}
