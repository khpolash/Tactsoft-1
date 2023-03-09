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
    public class Award:BaseEntity
    {
        [Required]
        [ForeignKey("AwardType")]
        [Display(Name ="Award Name")]
        public long? AwardTypeId { get; set; }
        [Required]
        [ForeignKey("Employee")]
        [Display(Name ="Employee Name")]
        public long? EmployeeId { get; set; }
        public double Prize { get; set; }
        public string Gift { get; set; }
        public DateTime Date { get; set; }
        public AwardType AwardType { get; set; }
        public Employee Employee { get; set; }

    }
}
