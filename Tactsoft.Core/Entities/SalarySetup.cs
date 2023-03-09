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
    public class SalarySetup:BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name = "Employee Name")]
        public long? EmployeeId { get; set; }
        public Double Basic { get; set; }

        public Employee Employee { get; set; }
        public IList<AllowensDetails> AllowensDetailss { get; set; }
    }
}
