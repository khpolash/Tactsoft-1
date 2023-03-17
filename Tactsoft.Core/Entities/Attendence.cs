using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public  class Attendence : BaseEntity
    {
        [Required]
        [DisplayName("Attendence Date")]
        public DateTime AttendenceDate { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public long EmployeeId { get; set; }
        [NotMapped]
        [DisplayName("Department")]
        public long DepartmentId { get; set; }
        public Boolean IsPresent { get; set; }

        public Employee Employee { get; set; }
    }
}
