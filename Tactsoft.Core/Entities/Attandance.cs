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
    public class Attandance:BaseEntity
    {
        [Required]
        [Display(Name ="Attandance Date")]
        public DateTime AttandanceDate { get; set; }
        [Required]
        [ForeignKey("Employee")]
        [Display(Name ="Employee Name")]
        public long? EmployeeId { get; set; }   
        public Employee Employee { get; set; }

        public Present Present { get; set; }    
        public string Remarks { get;set; }
    }
}
