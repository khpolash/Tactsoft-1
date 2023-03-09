using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public  class Allowens: BaseEntity
    {
        [Required]
        [Display(Name ="Allowens")]
        public string AllowensName { get; set; }
        public string Comment { get; set;}

        public IList<AllowensDetails> AllowensDetailss { get; set; }
    }
}
