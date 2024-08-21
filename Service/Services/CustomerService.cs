using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustomerService(IGenericRepository<Customer> repository, IUnitOfWorks unitOfWorks , ICustomerRepository customerRepository) : Service<Customer>(repository, unitOfWorks), ICustomerService
    {
        private readonly ICustomerRepository customerRepository = customerRepository    ;
    }
}
