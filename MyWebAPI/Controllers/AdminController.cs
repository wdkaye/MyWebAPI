using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<AppUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            AppUser? user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return Unauthorized("Bad user name.");
            }

            bool success = await userManager.CheckPasswordAsync(user, request.Password);
            if (!success)
            {
                return Unauthorized("Incorrect password.");
            }

            JwtSecurityToken token = await jwtHandler.GetTokenAsync(user);

            string jwtString = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponse response = new() 
            { 
                Success = true,
                Message = "Ohhhhh Yeahhh!!",
                Token = jwtString
            };

            return Ok(response);
        }
    }
}

