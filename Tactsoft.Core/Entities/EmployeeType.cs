using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class EmployeeType:BaseEntity
    {
        public Boolean Sat { get;set; }
        public Boolean Sun { get; set; }
        public Boolean Mon { get; set; }
        public Boolean Tue { get; set; }
        public Boolean Wed { get; set; }
        public Boolean Thu { get; set; }
        public Boolean Fri { get; set; }

        [Display(Name ="Parmanent Date")]
        [Column(TypeName = "date")]
        public DateTime DateOfParmanent { get; set; }
        public string Remarks { get; set; }
    }
}
