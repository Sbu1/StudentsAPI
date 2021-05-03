using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;
using StudentAttendanceAPI.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAttendanceTests
{
    public class Tests
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        protected ApplicationDbContext _dbContext;
        private ClassService _classService;
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

            _classService = new ClassService(_dbContext);
            await SetupStudentAttendanceData();
        }

        private async Task SetupStudentAttendanceData()
        {
            using (var db = new ApplicationDbContext(_dbContextOptions))
            {
                var user = new ApplicationUser
                {
                    UserName = "User1",
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000000").ToString()
                };
                var user2 = new ApplicationUser
                {
                    UserName = "User2",
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000000").ToString()
                };
                var user3 = new ApplicationUser
                {
                    UserName = "User3",
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000000").ToString()
                };


                await db.Users.AddRangeAsync(user, user2, user3);
                await db.SaveChangesAsync();


                var class1 = new TbClass
                {
                    ClassName = "Class 1",
                    UserId = Guid.Parse("10000000-0000-0000-0000-000000000000").ToString()
                };

                var class2 = new TbClass
                {
                    ClassName = "Class 2",
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000000").ToString()
                };

                var class3 = new TbClass
                {
                    ClassName = "Class 3",
                    UserId = Guid.Parse("10000000-0000-0000-0000-000000000000").ToString()
                };

                await db.TbClass.AddRangeAsync(class1, class2);
                await db.SaveChangesAsync();
            }
        }

        [Test]
        public async Task AddClassAsync_GivenValidClass_ShouldReturn1()
        {
            var class1 = new ClassModel
            {
                ClassName = "Class 3"
            };
            var username = "User1";

            var result = await _classService.AddClassAsync(class1, username);

            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task AddClassAsync_GivenInvalidUsername_ShouldThrowException()
        {
            var class1 = new ClassModel
            {
                ClassName = "Class 4"
            };
            var username = "InvalidUser";

            Assert.ThrowsAsync<ArgumentException>(async () => await _classService.AddClassAsync(class1, username));
        }


        [Test]
        public async Task GetClassessAsync_GivenValidUsername_ShouldReturnAListOfClasses()
        {
            var username = "User1";

            var result = await _classService.GetClassesAsync(username);

            Assert.Greater(result.Count(), 0);
        }

        [Test]
        public async Task GetClassessAsync_GivenInValidUsername_ShouldReturnThrowException()
        {
            var username = "InvalidUser";

            Assert.ThrowsAsync<ArgumentException>(async () => await _classService.GetClassesAsync(username));
        }

        [Test]
        public async Task GetClassessAsync_GivenValidUsernameWithNoClasses_ShouldReturnEmptyList()
        {
            var username = "User3";

            var result = await _classService.GetClassesAsync(username);

            Assert.AreEqual(0, result.Count);
            Assert.IsNotNull(result);
        }
    }
}