using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class MaritialStatus:BaseEntity
    {
        [Required]
        [Display(Name ="Maritial Status")]
        public string MaritialStatusName { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
