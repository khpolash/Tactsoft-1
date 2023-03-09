using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace Tactsoft.Core.Entities
{
    public class BloodGroup:BaseEntity
    {

        [Required]
        [Display(Name = "Blood Group")]
        public string BloodGroupName { get; set; }
        public IList<Employee> Employees { get; set; }
        
    }
}
