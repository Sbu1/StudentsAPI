using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentAttendanceAPI.Services
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentAttendanceService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddStudentsRegister(List<StudentRegisterModel> studentRegisterModel)
        {
            foreach (var student in studentRegisterModel)
            {
               await AddStudent(student);
            }

            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<StudentAttendanceReportModel>> GetReportAsync(int classId, DateTime date)
        {
            var reports = await _applicationDbContext.TbStudentAttendance.Where(x=>x.Date == date.Date).Include(x => x.TbStudent).ThenInclude(x => x.TbClass).ToListAsync();
            var classReport = reports.Where(x => x.TbStudent.ClassId == classId);

            var attendancereport = new List<StudentAttendanceReportModel>();

            foreach (var report in classReport)
            {
                attendancereport.Add(new StudentAttendanceReportModel
                {
                    ClassName = report.TbStudent.TbClass.ClassName,
                    Date = report.Date,
                    Grade = report.TbStudent.Grade,
                    Attendend = report.Attended,
                    StudentName = string.Concat(report.TbStudent.FirstName, " ", report.TbStudent.LastName)
                });
            }
            return attendancereport;
        }

        public async Task<List<StudentAttendanceReportModel>> GetReportAsync(int classId, DateTime startdate, DateTime endDate)
        {
            var reports = await _applicationDbContext.TbStudentAttendance.Where(x => x.Date >= startdate.Date && x.Date <= endDate).Include(x => x.TbStudent).ThenInclude(x => x.TbClass).ToListAsync();
            var classReport = reports.Where(x => x.TbStudent.ClassId == classId);

            var attendancereport = new List<StudentAttendanceReportModel>();

            foreach (var report in classReport)
            {
                attendancereport.Add(new StudentAttendanceReportModel
                {
                    ClassName = report.TbStudent.TbClass.ClassName,
                    Date = report.Date,
                    Grade = report.TbStudent.Grade,
                    Attendend = report.Attended,
                    StudentName = string.Concat(report.TbStudent.FirstName, " ", report.TbStudent.LastName)
                });
            }
            return attendancereport;
        }

        private async Task AddStudent(StudentRegisterModel studentRegisterModel)
        {
            await _applicationDbContext.AddAsync(new TbStudentAttendance
            {
                Attended = studentRegisterModel.Present,
                StudentId = studentRegisterModel.StudentId,
                Date = DateTime.Now
            });
        }
    }
}
