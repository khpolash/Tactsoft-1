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
    public class BranchInfo:BaseEntity
    {
        [Required]
        [Display(Name ="Branch Name")]
        public string BranceName { get; set; }
        [Required]
        [Display(Name ="Branch Address")]
        public string BranchAddress { get; set; }
        [Required]
        [ForeignKey("CompanyInfo")]
        [Display(Name ="Company Info")]
        public long? CompanyInfoId { get; set; }
        [Required]
        [ForeignKey("Country")]
        [Display(Name ="Country Name")]
        public long? CountryId { get;set; }
        [Required]
        [ForeignKey("ZipCode")]
        [Display(Name ="ZipCode")]
        public long? ZipCodeId { get; set; }  
        [Required]
        [ForeignKey("State")]
        [Display(Name ="State Name")]
        public long? StateId { get;set; }
        [Required]
        [ForeignKey("City")]
        [Display(Name ="City Name")]
        public long? CityId { get; set; }
        public ZipCode ZipCode { get; set; }    
        [Required]
        public CompanyInfo CompanyInfo { get; set; }  
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        [Required]
        public string Email { get;set; }
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }
        public IList<Project> Projects { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<ServiceInfo> ServiceInfos { get; set; }
        public IList<Attendance> Attendances { get; set; }
    }
}
