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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        // GET: api/Student
        [HttpGet]
        [HttpGet("{classId}", Name = "GetStudents")]
        public async Task<ActionResult<StudentModel>> GetStudents(int classId)
        {
            return Ok(await _studentService.GetStudentsAsync(classId));
        }

        // GET: api/Student/5
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
