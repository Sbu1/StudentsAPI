using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;

namespace StudentAttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<ClassModel>> Get()
        {
            return Ok(await _classService.GetClasses(HttpContext.User.Identity.Name));
        }

        // POST: api/Class
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassModel classModel)
        {
            var result = await _classService.AddClassAsync(classModel, HttpContext.User.Identity.Name);
            return Ok(result);
        }

    }
}
