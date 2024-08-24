using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PaymentDto : BaseDTO
    {
        public int CustomerID { get; set; }
        public double Amount { get; set; }
        public CustomerDto? Customer { get; set; }
    }
}
