using StudentAttendanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Interface
{
    public interface IStudentRegister
    {
        Task<int> AddStudentsRegister(List<StudentRegisterModel> studentRegisterModel);

        Task<int> UpdateStudentRegister(int studentRegisterId, List<StudentRegisterModel> studentRegisterModel);

    }
}
