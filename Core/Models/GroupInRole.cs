﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class GroupInRole : BaseEntity
    {
        public int GroupId { get; set; }
        public int RoleID { get; set; }
        public Group Group { get; set; }
        public Role Role { get; set; }


    }
}