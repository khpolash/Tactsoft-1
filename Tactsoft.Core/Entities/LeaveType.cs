using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class LeaveType:BaseEntity
    {
        [Required]
        [Display(Name ="Leave Type")]
        public string LeaveTypeName { get; set; }
        public IList<LeaveApplication> LeaveApplications { get; set; }
    }
}
