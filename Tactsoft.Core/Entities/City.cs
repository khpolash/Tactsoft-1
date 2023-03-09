using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Entities
{
    public class City:BaseEntity
    {
        [Required]
        [Display(Name ="City Name")]
        public string CityName { get; set; }
        [Required]
        [Display(Name ="State Name")]
        public long? StateId { get; set; }
        public State State { get; set; }
         
        public IList<CompanyInfo> CompanyInfos { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<BranchInfo> BranchInfos { get; set; }
        public IList<ZipCode> ZipCodes { get; set; }
    }
}
