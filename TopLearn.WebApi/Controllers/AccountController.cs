using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TopLearn.DAL.Entities;
using TopLearn.WebApi.Repository.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<AccountController>
        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {

            var result = new ObjectResult(_userService.GetAllUsers())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            //Request.HttpContext.Response.Headers.Add("X-Count", _customerRepository.CountCustomer().ToString());
            Request.HttpContext.Response.Headers.Add("X-Name", "ALi Jahangir");

            return result;
        }

        // GET api/<AccountController>/5    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.FindUser(id);
            return Ok(user);
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var _user = await _userService.Register(user);
            return Ok(_user);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void PutUser(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}
