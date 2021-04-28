using StudentAttendanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Interface
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(StudentModel studentModel);
        Task<StudentModel> GetStudentAsync(int studentId);
        Task<List<StudentModel>> GetStudentsAsync(int teacherId);
        Task<int> UpdateStudentAsync(StudentModel studentModel);
    }
}
