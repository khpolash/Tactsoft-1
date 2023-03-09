using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class AdvanceType:BaseEntity
    {
        [Required]
        [Display(Name ="Advance Type")]
        public string AdvanceTypeName { get; set; }
        public IList<Advance> Advances { get; set; }
    }
}
