using Azure.Core;
using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> customResponseDto)
        {
            if (customResponseDto.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = customResponseDto.StatusCode
                };
            }
            return new ObjectResult(customResponseDto) { StatusCode =customResponseDto.StatusCode};

        }
        [NonAction]
        public int GetUserFromToken()
        {
            string request =  Request.Headers["Authorization"];
            string jwt = request?.Replace("Baerer", "");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(jwt) as JwtSecurityToken;
            string userID = token.Claims.FirstOrDefault(claim =>claim.Type =="sub")?.Value;
            int id = Int32.Parse(userID);
            return id == 0 ? 0 : id;
        }
    }
}
