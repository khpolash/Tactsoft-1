using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Entities
{
    public class State:BaseEntity
    {        
       public string StateName { get; set; }
        [Required]
        [Display(Name ="Country Name")]
        public long? CountryID { get; set; }
        public Country Country { get; set; }
        public IList<Country> Countries { get; set;}
        public IList<Employee> Employees { get; set;}
        public IList<City> Cities { get; set;}
        public IList<BranchInfo> BranchInfos { get; set;}
        public IList<CompanyInfo> CompanyInfos { get; set; }
    }
}
