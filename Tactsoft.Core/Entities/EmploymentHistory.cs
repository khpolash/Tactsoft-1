using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class EmploymentHistory:BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name ="Employee Name")]
        public long? EmployeeId { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string NameOfCompany{get;set; }
        [ForeignKey("Designation")]
        public long? DesignationId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime JobFor { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime JobTo { get; set;}
        [Required]
        public Double Salary { get; set;}
        [Required]
        [Display(Name ="Reason For Leaving")]
        public string ReasonForLeaving { get; set; }

        public Employee Employee { get; set; }
        public Designation Designation { get; set; }

    }
}
