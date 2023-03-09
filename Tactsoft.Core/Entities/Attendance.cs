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
    public class Attendance:BaseEntity
    {
        [Required]
        [ForeignKey("CompanyInfo")]
        [Display(Name ="Company Name")]
        public long? CompanyInfoId { get; set; }
        [Required]
        [ForeignKey("BranchInfo")]
        [Display(Name = "Branch Name")]
        public long? BranchInfoId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        [Display(Name = "Employee Name")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date {  get; set; }
        [Column(TypeName = "Date")]
        public  DateTime Intime { get; set; }
        [Display(Name ="Intime Number")]
        public Double IntimeNumber { get; set; }
        [Column(TypeName = "Date")]
        public DateTime OutTime { get; set; }
        [Display(Name ="OutTime Number")]
        public Double OutTimeNumber { get; set; }
        public string EntryType { get; set; }

        public CompanyInfo CompanyInfo { get; set; }
        public Employee Employee { get; set; }
        public BranchInfo BranchInfo { get; set; }

    }
}
