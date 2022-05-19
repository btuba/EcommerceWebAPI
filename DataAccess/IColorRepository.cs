using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<IEnumerable<Color>> GetColorsByName(string name);
        //Task<IEnumerable<Color>> GetColorByName(string name);
    }
}
