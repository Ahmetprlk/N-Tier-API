using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Hashing;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            Token token = await _userService.Login(userLoginDto);
            if (token == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(401, "Bilgi Uyuşmadı");

            }
            return CreateActionResult(CustomResponseDto<Token>.Success(200, token));   
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            int id = 1;
            var entity = mapper.Map<Customer>(userDto);
            entity.UpdatedBy = id;
            entity.CreatedBy = id;

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(userDto.Password, out passwordHash, out passwordSalt);

            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            var user  = await _userService.AddAsync(entity);
            var userResponseDto = mapper.Map<UserDto>(userDto);

            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, userDto));

        }
    }
}
