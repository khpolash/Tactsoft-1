using Microsoft.AspNetCore.Http;
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
    public class Attachment : BaseEntity
    {
        
        [Display(Name = "Attachment File")]
        public string AttachmentFile { get; set; }

        //[Required]
        //public IFormFile DocumentFile { get; set; }

        [Required]
        [ForeignKey("Employee")]

        [Display(Name = "Employee Name")]
        public long? EmployeeId { get; set; }
        [Required]
        [ForeignKey("AttachmentType")]

        [Display(Name = "Attachment Type")]
        public long? AttachmentTyppeId { get; set; }

        public Employee Employee { get; set; }
        public AttachmentType AttachmentType { get; set; }
        public IList<LeaveApplication> LeaveApplications { get; set; }   
    }
}
