using StudentAttendanceAPI.Authentication;
using StudentAttendanceAPI.Interface;
using StudentAttendanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Services
{
    public class ClassService : IClassService
    {
        private readonly ApplicationDbContext _dbContext;
        public ClassService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<int> AddClassAsync(ClassModel classModel)
        {
            await _dbContext.AddAsync(classModel);
            var result = await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
