using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Errors.Any())
            {
                return CreatedAtRoute("GetUser", new { controller = "account", id = user.Id }, "User created successfully");
            }

            return BadRequest(result.Errors.Select(error => error.Description).ToList());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new {error = "Please check email and password"});
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return BadRequest("user name does not exist");
            var isAuthenticated = await _userManager.CheckPasswordAsync(user, model.Password);
            if (isAuthenticated) return Ok("Username password valid");
            return Unauthorized("Username password is invalid");
        }
    }
}
