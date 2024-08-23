using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            Token token = await _userService.Login(userLoginDto);
            if (token == null)
            {
               return CreateActionResult(CustomeResponseDto<NoContentDto>.Fail(401, "Bilgi Uyuşmadı");
            }
            return CreateActionResult(CustomResponseDto<Token>.Success(200, token));   
        }

    }
}
