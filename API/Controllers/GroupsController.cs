using AutoMapper;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;

        private readonly IMapper mapper;
        public GroupsController(IGroupService groupService, IMapper mapper)
        {
            this.groupService = groupService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {
            var groups = groupService.GetAll();
            var dtos = mapper.Map<List<GrroupDto>>(groups).ToList();

            return CreateActionResult(CustomResponseDto<List<GrroupDto>>.Success(200, dtos));
        }

    }
}
