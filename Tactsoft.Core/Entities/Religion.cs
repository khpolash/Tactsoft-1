using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Religion:BaseEntity
    {
        
        [Display(Name ="Religion Name")]
        public string ReligionName { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
