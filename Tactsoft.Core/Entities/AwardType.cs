using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class AwardType:BaseEntity
    {
        [Required]
        [Display(Name ="Award Type")]
        public string AwardTypeName { get; set; }

        public IList<Award> Awards { get; set; }
    }
}
