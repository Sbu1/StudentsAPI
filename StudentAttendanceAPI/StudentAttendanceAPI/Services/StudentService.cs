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
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<int> AddStudentAsync(StudentModel studentModel)
        {
            var studentClass = await _dbContext.TbClass.FindAsync(studentModel.classId);

            if (studentClass == null)
                throw new ArgumentException("Invalid Class Id"); //Add exceptions middleware

            var student = new TbStudent
            {
                ClassId = studentModel.classId,
                FirstName = studentModel.FirstName,
                Gender = studentModel.Gender,
                Grade = studentModel.Grade,
                LastName = studentModel.LastName,
                ParentCellNumber = studentModel.ParentPhoneNumber,
                ParentEmail = studentModel.ParentEmail
            };

            await _dbContext.TbStudent.AddAsync(student);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<StudentModel> GetStudentAsync(int studentId)
        {
            var result = await _dbContext.TbStudent.FindAsync(studentId);

            var studentModel = new StudentModel
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Gender = result.Gender,
                Grade = result.Grade,
                ParentEmail = result.ParentEmail,
                ParentPhoneNumber = result.ParentCellNumber
            };

            return studentModel;
        }

        public async Task<List<StudentModel>> GetStudentsAsync(int classId)
        {
            var result = await _dbContext.TbStudent.Where(x => x.ClassId == classId).ToListAsync();
            var students = new List<StudentModel>();

            if (result != null)
            {
                foreach (var student in result)
                {
                    var studentModel = new StudentModel
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Gender = student.Gender,
                        Grade = student.Grade,
                        ParentEmail = student.ParentEmail,
                        ParentPhoneNumber = student.ParentCellNumber
                    };

                    students.Add(studentModel);
                }
            }
            return students;
        }

        public async Task<int> UpdateStudentAsync(StudentModel studentModel)
        {
            var result = await _dbContext.TbStudent.FindAsync(studentModel.StudentId);

            result.FirstName = studentModel.FirstName;
            result.LastName = studentModel.LastName;
            result.ParentCellNumber = studentModel.ParentPhoneNumber;
            result.ParentEmail = studentModel.ParentEmail;
            result.Grade = studentModel.Grade;
            result.ClassId = studentModel.classId;

            _dbContext.Update(result);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
