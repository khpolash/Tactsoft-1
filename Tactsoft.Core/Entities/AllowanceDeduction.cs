using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class AllowanceDeduction:BaseEntity
    {
        [Required]
        [Display(Name ="Allowance/Deduction Name")]
        public string AllowanceDeductionName { get;set; }
        [Required]
        [Display(Name ="Alloowance / Deduction type")]
        public string AllowanceDeductionType { get;set; }

        public IList<SalarySetup> SalarySetups { get; set; }
    }
}
