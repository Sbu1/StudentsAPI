using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(6)")]
        public string Gender { get; set; }
        [Required]
        public int ParentPhoneNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string ParentEmail { get; set; }
        [Required]
        [Range(1, 12)]
        public int Grade { get; set; }
    }
}
