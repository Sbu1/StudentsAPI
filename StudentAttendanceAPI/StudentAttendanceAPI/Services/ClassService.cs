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
        public Task<Class> AddClass(Class classModel)
        {
            return Task.FromResult(new Class { });
        }
    }
}
