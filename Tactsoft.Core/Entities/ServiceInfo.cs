using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class ServiceInfo : BaseEntity
    {

        [ForeignKey("Employee")]
        [Display(Name = "Employee Name")]
        public long? EmployeeId { get; set; }

        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        [ForeignKey("Department")]

        [Display(Name = "Department")]
        public long? DepartmentId { get; set; }

        [ForeignKey("Degination")]
        [Display(Name = "Degination")]
        public long? DesignationId { get; set; }

        [ForeignKey("BranchInfo")]
        [Display(Name = "Branch Name")]
        public long? BranchId { get; set; }
        public string Remarks { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
        public BranchInfo BranchInfo { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceInfoName { get; set; }
    }
}
