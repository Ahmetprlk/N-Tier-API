﻿using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupInRoleRepository(AppDbContext context):GenericRepository<GroupInRole>(context),IGroupInRoleRepository
    {
    }
}