using StudentAttendanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Interface
{
    public interface IStudentAttendanceService
    {
        Task<int> AddStudentsRegister(List<StudentRegisterModel> studentRegisterModel);

        Task<List<StudentAttendanceReportModel>> GetReportAsync(int classId, DateTime date);

        Task<List<StudentAttendanceReportModel>> GetReportAsync(int classId, DateTime startdate, DateTime endDate);

    }
}
