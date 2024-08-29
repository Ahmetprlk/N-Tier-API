using API.Filters;
using AutoMapper;
using Core.DTOs.UpdateDtos;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : CustomBaseController
    {
        private readonly IDepartmentService service;
        private readonly IMapper mapper;
        public DepartmentsController(IDepartmentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cutomers = service.GetAll();
            var dtos = mapper.Map<List<DepartmantDto>>(cutomers).ToList();

            return CreateActionResult(CustomResponseDto<List<DepartmantDto>>.Success(200, dtos));
        }
        [ServiceFilter(typeof(NotFounFilter<Department>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var departments = await service.GetByIDAsync(id);
            var departmentdtos = mapper.Map<DepartmantDto>(departments);
            return CreateActionResult(CustomResponseDto<DepartmantDto>.Success(200, departmentdtos));
        }
        [ServiceFilter(typeof(NotFounFilter<Department>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = 1;
            var department = await service.GetByIDAsync(id);
            department.UpdatedBy = userId;
            service.ChangesStatus(department);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpPost]
        public async Task<IActionResult> Save(DepartmantDto departmentdto)
        {
            int id = GetUserFromToken();
            var entity = mapper.Map<Department>(departmentdto);
            entity.UpdatedBy = id;
            entity.CreatedBy = id;

            var department = await service.AddAsync(entity);
            var departmentResponseDto = mapper.Map<DepartmantDto>(departmentdto);

            return CreateActionResult(CustomResponseDto<DepartmantDto>.Success(201, departmentdto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(DepartmentUpdateDto departmentDto)
        {
            int userId = 1;
            var current = await service.GetByIDAsync(departmentDto.Id);
            current.UpdatedBy = userId;
            current.Name = departmentDto.Name;
            service.Update(current);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

    }
}
