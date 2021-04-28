
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Models
{
    public class StudentRegisterModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public bool Present { get; set; }
    }
}
