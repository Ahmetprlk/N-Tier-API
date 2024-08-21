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
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IGenericRepository<Role> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
        {
        }
    }
}
