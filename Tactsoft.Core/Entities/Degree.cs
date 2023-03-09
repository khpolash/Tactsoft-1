using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Degree:BaseEntity
    {
        [Required]
        [Display(Name ="Degree")]
        public string DegreeName { get; set; }
        public IList<Education> Educations { get; set; }
    }
}
