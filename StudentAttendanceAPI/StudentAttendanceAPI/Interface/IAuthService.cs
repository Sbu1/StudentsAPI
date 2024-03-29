﻿using StudentAttendanceAPI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Interface
{
    public interface IAuthService
    {
        Task<Response> RegisterAsync(RegisterModel registerModel, bool admin);
    }
}
