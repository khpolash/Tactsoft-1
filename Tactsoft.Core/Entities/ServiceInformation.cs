using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class ServiceInformation:BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name ="Employee Name")]
        public long? EmployeeId { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        [ForeignKey("Designation")]
        [Display(Name ="Designation")]
        public long? DesignationId { get; set; }
        [Required]
        [ForeignKey("Depertment")]
        [Display(Name ="Depertment")]
        public long? DepertmentId { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
                
    }
}
