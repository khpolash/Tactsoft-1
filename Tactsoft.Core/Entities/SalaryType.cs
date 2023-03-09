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
    public class SalaryType:BaseEntity
    {
        [Required]
        [Display(Name ="Salary Type")]
        public string SalaryTypeName { get; set; }
        
    }
}
