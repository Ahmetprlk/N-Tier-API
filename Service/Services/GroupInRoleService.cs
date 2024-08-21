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
    public class GroupInRoleService : Service<GroupInRole>, IGroupInRoleService
    {
        public GroupInRoleService(IGenericRepository<GroupInRole> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
        {
        }
    }
}
