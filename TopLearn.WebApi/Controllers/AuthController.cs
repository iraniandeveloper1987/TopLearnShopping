using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using TopLearn.Core.DTOs.AccountViewModels;
using TopLearn.WebApi.Repository.Contracts;

namespace TopLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> PostLogin(LoginEmailViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model Is Not Valid");
            }

            var user = await _userService.Login(login);

            if (user == null)
            {
                return Unauthorized();
            }


            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurVerifyTopLearn"));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOption = new JwtSecurityToken(
                issuer: "http://localhost:5395",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim(ClaimTypes.NameIdentifier,user.UserName),
                    new Claim("Roles",user.RoleUsers.First().Role.RoleName)
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

            return Ok(new { token = tokenString });
        }
    }
}
