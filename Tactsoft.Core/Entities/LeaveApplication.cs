using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class LeaveApplication : BaseEntity
    {
        [ForeignKey("Employee")]
        [Display(Name = "Employee Name")]
        public long? EmployeeId { get; set; }

        [ForeignKey("LeaveType")]
        [Display(Name = "Leave Type")]
        public long? LeaveTypeId { get; set; }
        [Display(Name ="Attachment File")]
        public string AttachmentFile { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }

        public LeaveType LeaveType { get; set; }
        public Employee Employee { get; set; }
        






    }
}
