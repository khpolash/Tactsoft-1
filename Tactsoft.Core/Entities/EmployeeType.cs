using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class EmployeeType:BaseEntity
    {
        [Display(Name ="Parmanent Date")]
        public DateTime DateOfParmanent { get; set; }
        public string Remarks { get; set; }
    }
}
