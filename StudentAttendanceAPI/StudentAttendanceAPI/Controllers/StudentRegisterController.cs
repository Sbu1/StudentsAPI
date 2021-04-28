using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;

namespace StudentAttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegisterController : ControllerBase
    {
        private readonly IStudentRegister _studentRegister;

        public StudentRegisterController(IStudentRegister studentRegister)
        {
            _studentRegister = studentRegister;
        }
        // POST: api/StudentRegister
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] List<StudentRegisterModel> studentRegisterModel)
        {
            return await _studentRegister.AddStudentsRegister(studentRegisterModel);
        }
    }
}
