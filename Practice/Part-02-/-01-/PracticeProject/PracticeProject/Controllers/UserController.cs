using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeProject.DTOs.User;
using PracticeProject.Models;
using PracticeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserRegistrationDTO userRegistrationDTO)
        {
            var newUser = _userService.FindByEmail(userRegistrationDTO.Email);
            if (newUser != null)
            {
                return BadRequest("User Already Exist");
            }
            newUser = _userService.AddUser(userRegistrationDTO);
            return Ok();
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = _userService.LoginUser(userLoginDTO)
                ?? throw new Exception("Invalid User Or Password");
            return Ok(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
