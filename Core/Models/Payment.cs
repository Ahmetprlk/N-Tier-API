﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Payment : BaseEntity
    {
        public int CustomerID { get; set; }
        public double Amount { get; set; }
        public Customer Customer { get; set; }
    }
}
