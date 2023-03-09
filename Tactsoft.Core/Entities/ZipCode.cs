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
    public class ZipCode:BaseEntity
    {
        [Required]
        [Display(Name ="ZipCode")]
        public string ZipCodeName { get; set; }
        [Required]
        [ForeignKey("City")]
        [Display(Name ="City Name")]
        public long? CityId { get; set; }
        public City City { get; set; }

        public IList<BranchInfo> BranchInfos { get; set; }
        public IList<CompanyInfo> CompanyInfos { get; set; }
    }
}
