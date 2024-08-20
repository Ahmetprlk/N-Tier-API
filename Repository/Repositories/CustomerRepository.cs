﻿using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CustomerRepository(AppDbContext context) : GenericRepository<Customer>(context),ICustomerRepository
    {

    }
}
