using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class GroupInRoleDto : BaseDTO
    {
        public int GroupId { get; set; }
        public int RoleID { get; set; }
        public Group Group { get; set; }
        public Role Role { get; set; }
    }
}
