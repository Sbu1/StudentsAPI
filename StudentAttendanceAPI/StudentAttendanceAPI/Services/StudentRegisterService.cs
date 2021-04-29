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
    public class StudentRegisterService : IStudentRegister
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentRegisterService(ApplicationDbContext applicationDbContext)
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

        public async Task<int> UpdateStudentRegister(int studentRegisterId, List<StudentRegisterModel> studentRegisterModel)
        {
            var register = await _applicationDbContext.TbStudentRegisters.Where (x => x.StudentRegisterId == studentRegisterId).ToListAsync();

            foreach (var student in studentRegisterModel)
            {

            }

            return await Task.FromResult(0);
        }

        private async Task AddStudent(StudentRegisterModel studentRegisterModel)
        {
            await _applicationDbContext.AddAsync(new TbStudentRegister
            {
                Present = studentRegisterModel.Present,
                StudentId = studentRegisterModel.StudentId
            });
        }
    }
}
