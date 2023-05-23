using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

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
                return CreatedAtAction("GetUser", new { controller = "account", id = user.Id }, "User created successfully");
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
            if (isAuthenticated)
            {
                return Ok(new {token = CreateJWT(user)});
            }
            // we need to create JWT and send to client(SPA, IOS, Android)
            return Unauthorized("Username password is invalid");
        }

        private string CreateJWT(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = "HRM",
                Audience = "HRM Users",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity( new []
                {
                    new Claim( JwtRegisteredClaimNames.Email, user.Email),
                    new Claim( JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim( JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim( JwtRegisteredClaimNames.GivenName, user.FirstName),
                    new Claim("language", "english")
                })
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Cannot find user with this id.");
            }

            return Ok(user);
        }
    }
}
