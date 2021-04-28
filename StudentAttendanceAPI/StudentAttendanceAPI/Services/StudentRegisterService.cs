using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Services
{
    public class StudentRegisterService : IStudentRegister
    {
        private readonly ApplicationDbContext applicationDbContext;
        public async Task<int> AddStudentsRegister(List<StudentRegisterModel> studentRegisterModel)
        {
            foreach (var student in studentRegisterModel)
            {
               await AddStudent(student);
            }

            return await applicationDbContext.SaveChangesAsync();
        }

        private async Task AddStudent(StudentRegisterModel studentRegisterModel)
        {
            var student = await applicationDbContext.TbStudent.FindAsync(studentRegisterModel.StudentId);
            await applicationDbContext.AddAsync(new TbStudentRegister
            {
                present = studentRegisterModel.Present,
                TbStudent = student
            });
        }
    }
}
