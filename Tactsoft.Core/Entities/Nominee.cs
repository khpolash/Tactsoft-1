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
    public class Nominee : BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name = "Employee Name")]
        public long? EmployeeId { get; set; }
        [Display(Name = "Nominee Name")]
        public string NomineeName { get; set; }
       
        [Display(Name ="Nominee Picture")]
        public string Picture { get; set; }
        public string Address { get; set; }
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }
        public string percentage { get; set; }
        [Required]
        [ForeignKey("RelationShip")]
        [Display(Name ="Relationship")]
        public long? RelationShipId { get; set; }

        public Employee Employee { get; set; }
        public RelationShip RelationShip { get; set; }

    }
}
