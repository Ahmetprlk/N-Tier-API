using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UserDto : BaseDTO
    {
        public string Name { get; set; }
        public int DepartmanID { get; set; }
        public int GroupId { get; set; }

        public Department Department { get; set; }
        public Group Group { get; set; }
    }
}
