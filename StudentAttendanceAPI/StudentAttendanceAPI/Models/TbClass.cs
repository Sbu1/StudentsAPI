using StudentAttendanceAPI.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceAPI.Models
{
    public class TbClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string ClassName { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string UserName { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
