using API.Filters;
using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService service;
        private readonly IMapper mapper;
        public CustomersController(ICustomerService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All() { 
            var cutomers = service.GetAll();
            var dtos = mapper.Map<List<CustomerDto>>(cutomers).ToList();

            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200,dtos));
        }
        [ServiceFilter(typeof(NotFounFilter<Customer>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await service.GetByIDAsync(id);
            var customerdtos = mapper.Map<CustomerDto>(customers);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerdtos));
        }
        [ServiceFilter(typeof(NotFounFilter<Customer>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = 1;
            var customer = await service.GetByIDAsync(id);
            customer.UpdatedBy = userId;
            service.ChangesStatus(customer);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerdto)
        {
            int id = 1;
            var entity =mapper.Map<Customer>(customerdto);
            entity.UpdatedBy = id;
            entity.CreatedBy = id;

            var customer = await service.AddAsync(entity);

        }
    }
}
