using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Models
{
    public class StudentAttendanceReportModel
    {
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public string StudentName { get; set; }
        public bool Attendend { get; set; }
    }
}
