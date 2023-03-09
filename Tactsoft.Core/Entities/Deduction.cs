using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Deduction:BaseEntity
    {
        [Display(Name ="Deduction")]
        public string DeductionName { get; set; }
        public string Comment { get; set; }
    }
}
