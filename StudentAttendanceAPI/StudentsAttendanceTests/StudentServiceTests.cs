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

        [Test]
        public async Task AddStudentAsync_GivenValidStudent_ShouldReturn1()
        {
            var student5 = new StudentModel
            {
                classId = 3,
                FirstName = "testuser5",
                Gender = "male",
                Grade = 1,
                LastName = "lastname",
                ParentEmail = "s@g.com",
                ParentPhoneNumber = "1234512345"
            };

            var result = await _studentService.AddStudentAsync(student5);

            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task AddStudentAsync_GivenStudentWithoutClass_ShouldThrowException()
        {
            var student5 = new StudentModel
            {
                FirstName = "testuser5",
                Gender = "male",
                Grade = 1,
                LastName = "lastname",
                ParentEmail = "s@g.com",
                ParentPhoneNumber = "1234512345"
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await _studentService.AddStudentAsync(student5));
        }

        [Test]
        public async Task GetStudentsAsync_GivenClassId_ShouldListOfStudent()
        {
            var classId = 1;

            var result = await _studentService.GetStudentsAsync(classId);

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Count, 1);
        }

        [Test]
        public async Task GetStudentsAsync_GivenInvalidClassId_ShouldReturnEmptyList()
        {
            var classId = -1;

            var result = await _studentService.GetStudentsAsync(classId);

            Assert.AreEqual(0, result.Count);
        }
    }
}
