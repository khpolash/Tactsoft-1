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
    public class Advance:BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name ="Employee Name")]
        public long? EmployeeId { get; set; }
        [Required]
        [ForeignKey("AdvanceType")]
        [Display(Name ="Advance Type")]
        public long? AdvanceTypeId { get; set; }
        [Required]
        [Display(Name ="Date")]
        [Column(TypeName = "Date")]
        public DateTime AdvanceDate { get; set; }
        [Required]
        [Display(Name ="Approve Amount")]
        public Double ApproveAmount { get; set; }
        [Required]
        [Display(Name ="Monthly Deduction")]
        public Double MonthlyDeduction { get; set; }
        [Required]
        [Display(Name ="Disburs Year")]
        public DateTime DisburseYear { get; set; }
        [Required]
        [Display(Name ="Disburse Month")]
        public Month DisburseMonth { get; set; }
        [Required]
        [Display(Name ="Approve By")]
        public string ApproveBy { get; set; }

        public Employee Employee { get; set; }
        public AdvanceType AdvanceType { get; set; }
    }
}
