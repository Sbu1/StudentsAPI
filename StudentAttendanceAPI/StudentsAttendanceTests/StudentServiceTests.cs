using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;
using StudentAttendanceAPI.Services;

namespace StudentsAttendanceTests
{
    public class StudentServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        protected ApplicationDbContext _dbContext;
        private StudentService _studentService;
        [SetUp]
        public async Task Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _dbContext = new ApplicationDbContext(_dbContextOptions);
            await _dbContext.Database.EnsureCreatedAsync();

            _studentService = new StudentService(_dbContext);
            await SetupStudentData();
        }

        private async Task SetupStudentData()
        {
            using (var db = new ApplicationDbContext(_dbContextOptions))
            {
                var student = new TbStudent
                {
                    ClassId = 1,
                    FirstName = "test1",
                    Gender = "male",
                    Grade = 1,
                    LastName = "lastname",
                    ParentEmail = "s@g.com",
                    ParentCellNumber = "1234512345"
                };
                var student2 = new TbStudent
                {
                    ClassId = 1,
                    FirstName = "testuser2",
                    Gender = "male",
                    Grade = 1,
                    LastName = "lastname",
                    ParentEmail = "s@g.com",
                    ParentCellNumber = "1234512345"
                };
                var student3 = new TbStudent
                {
                    ClassId = 2,
                    FirstName = "testuser3",
                    Gender = "male",
                    Grade = 1,
                    LastName = "lastname",
                    ParentEmail = "s@g.com",
                    ParentCellNumber = "1234512345"
                };
                var student4 = new TbStudent
                {
                    ClassId = 3,
                    FirstName = "testuser4",
                    Gender = "male",
                    Grade = 1,
                    LastName = "lastname",
                    ParentEmail = "s@g.com",
                    ParentCellNumber = "1234512345"
                };


                await db.TbStudent.AddRangeAsync(student, student2, student3, student4);
                await db.SaveChangesAsync();
            }
        }
    }
}
