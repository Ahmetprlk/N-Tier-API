using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DepartmantDto : BaseDTO
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
