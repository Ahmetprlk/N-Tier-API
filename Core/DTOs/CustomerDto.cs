using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CustomerDto:BaseDTO
    {
        public string Name { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
