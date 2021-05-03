using Microsoft.AspNetCore.Identity;
using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Services
{
    public class authService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public authService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> RegisterAsync(RegisterModel registerModel, bool  admin)
        {
            var userExist = await _userManager.FindByNameAsync(registerModel.UserName);
            if (userExist != null)
                return new Response { StatusCode = 500, Message = "User already exist" };

            ApplicationUser user = new ApplicationUser()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return new Response { StatusCode = 500, Message = "User creation failed" };
            }

            return new Response { StatusCode = 200, Message = "User created successful" };
        }

    }
}
