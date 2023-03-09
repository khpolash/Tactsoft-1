using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Designation : BaseEntity
    {
        [Required]
        [Display(Name = "Designation")]
        public string DesignationName { get; set; }
        public IList<ServiceInfo> ServiceInfos { get; set; }
        public IList<EmploymentHistory> EmploymentHistorys { get; set; }
    }
}
