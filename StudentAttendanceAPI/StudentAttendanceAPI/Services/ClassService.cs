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
    public class ClassService : IClassService
    {
        private readonly ApplicationDbContext _dbContext;
        public ClassService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<int> AddClassAsync(ClassModel classModel, string username)
        {
            await _dbContext.TbClass.AddAsync(new TbClass
            {
                ClassName = classModel.ClassName,
                UserId = await getUserIdAsync(username)
            });

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }

        private async Task<string> getUserIdAsync(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
            return user.Id;
        }
    }
}
