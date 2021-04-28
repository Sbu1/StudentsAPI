using StudentAttendanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Interface
{
    public interface IClassService
    {
        Task<int> AddClassAsync(ClassModel classModel);
    }
}
