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
    public class FamilyMember:BaseEntity
    {
        [Required]
        [ForeignKey("Employee")]
        [Display(Name ="Employee")]
        public long? EmployeeId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string FamilyMemberName { get; set; }
        [Required]
        [ForeignKey("Relation Ship")]  
        [Display(Name ="Relationship")]
        public long? RelationShipId { get; set; }
        [Required]
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public Employee Employee { get; set; }
        public RelationShip RelationShip { get; set; }
    }
}
