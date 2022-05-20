using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class OrderDisplayResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Product> Products { get; set; }
        public Payment Payment { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCompleted { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}
