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
    public class StudentAttendanceController : ControllerBase
    {
        private readonly IStudentAttendanceService _studentRegister;

        public StudentAttendanceController(IStudentAttendanceService studentRegister)
        {
            _studentRegister = studentRegister;
        }
        // POST: api/StudentRegister
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] List<StudentRegisterModel> studentRegisterModel)
        {
            return await _studentRegister.AddStudentsRegister(studentRegisterModel);
        }

        [HttpGet("{classId}/{date}")]
        public async Task<List<StudentAttendanceReportModel>> Get(int classId, DateTime date)
        {
            return await _studentRegister.GetReportAsync(classId, date);
        }

        [HttpGet("{classId}/{startDate}/{endDate}")]
        public async Task<List<StudentAttendanceReportModel>> Get(int classId, DateTime startDate, DateTime endDate)
        {
            return await _studentRegister.GetReportAsync(classId, startDate, endDate);
        }
    }
}
