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
    public class AllowensDetails:BaseEntity
    {
        [Required]
        [ForeignKey("SalarySetup")]
        public long? SalarySetupId { get; set; }
        public Double Amount { get; set; }
        [Required]
        [ForeignKey("Allowens")]
        public long? AllowensId { get; set;}

        public SalarySetup SalarySetup { get; set; }
        public Allowens Allowens { get; set; }
    }
}
