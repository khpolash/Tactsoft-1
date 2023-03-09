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
    public class Project:BaseEntity
    {
        [Required]
        [Display(Name="Project Name")]
        public string ProjectName{get;set;}
        [Required]
        [ForeignKey("CompanyInfo")]
        [Display(Name ="Company Name")]
        public long? CompanyInfoId { get;set;}
        [Required]
        [ForeignKey("BranchInfo")]
        [Display(Name ="Branch Name")]
        public long? BranchInfoId { get;set;}
        [Display(Name ="Project Description")]
        public string ProjectDescription { get;set;}
        public string Duraction { get;set;}
        [Required]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get;set;}
        [Required]
        [Display(Name ="End Date")]
        public DateTime EndDate { get;set;}
        public CompanyInfo CompanyInfo { get;set;}
        public BranchInfo BranchInfo { get;set;}
        public IList<Project> Projects { get; set; }
        public IList<Employee> Employees { get; set; }
      

    }
}
