using AutoMapper;
using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Customer , CustomerDto>().ReverseMap();
            CreateMap<Department , DepartmantDto>().ReverseMap();
            CreateMap<Group , GrroupDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<GroupInRole, GroupInRoleDto>().ReverseMap();


        }
    }
}
