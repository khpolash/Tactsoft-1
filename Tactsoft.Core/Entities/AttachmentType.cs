using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class AttachmentType:BaseEntity
    {
        [Required]
        [Display(Name ="Attachment Type")]
        public string AttachmentTypeName { get; set; }


        public IList<Attachment> Attachments { get; set;}
        public IList<LeaveApplication> LeaveApplications { get; set;}
    }
}
