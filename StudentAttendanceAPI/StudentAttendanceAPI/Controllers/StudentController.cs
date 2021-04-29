using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;

namespace StudentAttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [HttpGet("{classId}", Name = "GetStudents")]
        public async Task<ActionResult<StudentModel>> GetStudents(int classId)
        {
            return Ok(await _studentService.GetStudentsAsync(classId));
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<StudentModel>> GetStudent(int studentId)
        {
            return Ok(await _studentService.GetStudentAsync(studentId));
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<int>> AddStudent([FromBody] StudentModel studentModel)
        {
            return Ok(await _studentService.AddStudentAsync(studentModel));
        }

        // PUT: api/Student/5
        [HttpPut]
        public async Task<ActionResult<int>> UpdateStudent([FromBody] StudentModel studentModel)
        {
            return Ok(await _studentService.UpdateStudentAsync(studentModel));
        }
    }
}
