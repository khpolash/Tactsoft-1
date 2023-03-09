using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.Entities
{
    public class Country:BaseEntity
    {
        [Required]
        [Display(Name ="Country Name")]
        public string CountryName { get; set; }
        [Required]
        [Display(Name ="Country Code")]
        public string CountryCode { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<CompanyInfo> CompanyInfos { get; set; }
        public IList<BranchInfo> BranchInfos { get; set; }
        public IList<State> States { get; set; }

    }
}
