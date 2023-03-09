using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class EducationGroup : BaseEntity
    {
        [Required]
        [Display(Name = "Education Group")]

        public string EducationGroupName { get; set; }
        public IList<Education> Educations { get; set; }
    }
}
