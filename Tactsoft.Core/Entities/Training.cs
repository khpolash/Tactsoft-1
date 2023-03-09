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
    public class Training : BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name = "Employee")]
        public long? EmployeeId { get; set; }
        [Required]
        [Display(Name = "Training Name")]

        public string TrainingName { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public Employee Employee { get; set; }
        [Required]
        [Display(Name = "Organigation Name")]
        public string OrganigationName { get; set; }
    }
}
