using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Models
{
    public class TbStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(6)")]
        public string Gender { get; set; }
        public int Grade { get; set; }
        public string ParentCellNumber { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ParentEmail { get; set; }

        [ForeignKey("TbClass")]
        public virtual int ClassId { get; set; }

        public virtual TbClass TbClass { get; set; }
    }
}
