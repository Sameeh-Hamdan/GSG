using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practice02.Data.ModelViews.User;
using Practice02.Data.Services.Users;
using Practice02.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practice02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            var newRegister=_userService.RegisterUser(registerUserDTO)
                ?? throw new Exception("Email Is already Exist");
            return Ok(newRegister);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserDTO loginUserDTO)
        {
            var user = _userService.LoginUser(loginUserDTO)
                ?? throw new Exception("Invalid User Or Password");
            return Ok(user);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
