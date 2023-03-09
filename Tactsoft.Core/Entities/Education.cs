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
    public class Education : BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name = "Employee")]

        public long? EmployeeId { get; set; }
        [Required]
        [ForeignKey("Degree")]

        [Display(Name = "Degree")]
        public long? DegreeId { get; set; }
        [Required]
        [ForeignKey("EducationGroup")]

        [Display(Name = "Education Group")]
        public long? EducationGroupId { get; set; }
        [Required]
        [Display(Name = "Institute Name")]

        public string InstituteName { get; set; }
        [Required]
        [Display(Name = "Passing Year")]

        public string PassingYear { get; set; }
        public string Remarks { get; set; }

        public string Result { get; set; }
        public Employee Employee { get; set; }
        public EducationGroup EducationGroup { get; set; }
        public Degree Degree { get; set; }

    }
}
