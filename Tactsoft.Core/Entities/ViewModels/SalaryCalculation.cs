using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tactsoft.Core.Entities.ViewModels
{
    public  class SalaryCalculation
    {
        public SalaryCalculation() 
        {
            SalarySetupList = new Collection<SalarySetupList>();
            BasicSalarySetupVMs = new Collection<BasicSalarySetupVM>();
        }

        [Required]
        [DisplayName("Employee")]
        public long Employee { get; set; }
        public ICollection<SalarySetupList>SalarySetupList { get; set; }
        public ICollection<BasicSalarySetupVM>BasicSalarySetupVMs { get; set; }
    }
    public class SalarySetupList
    {
        public long SalarySetupId { get; set; }
        public long AllowanceDeductionId { get; set; }
        public string AllowanceDeductionName { get; set; }
        public string AllowanceDeductionType { get; set; }
        public Boolean IsPercent { get; set; }
        public double Value { get; set; }
    }
    public class BasicSalarySetupVM
    {
        public double BasicSalary { get; set; }
    }
}
