using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Models
{
    public class TbStudentRegister
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentRegisterId { get; set; }
        [Required]
        public bool present { get; set; }

        [ForeignKey("TbStudent")]
        public virtual int StudentId { get; set; }
        public virtual TbStudent TbStudent { get; set; }
    }
}
