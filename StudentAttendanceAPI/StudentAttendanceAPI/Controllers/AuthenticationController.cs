using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;

namespace StudentAttendanceAPI.Controllers
{
    [Route("api/[controller]")] //NB routing
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IAuthService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authService.RegisterAsync(registerModel, false); //TODO TESTING

            return Ok(new Response { Status = "Success", Message = "USer created successful" });
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(7),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] RegisterModel registerModel)
        {
            var result = await _authService.RegisterAsync(registerModel, true); //TODO handle response

            return Ok(new Response { Status = "Success", Message = "USer created successful" });
        }
    }
}