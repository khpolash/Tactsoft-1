using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Reference : BaseEntity
    {
        [Required]
        [Display(Name ="Name")]
        public string ReferenceName{get;set;}
        [Required]
        public string Address { get;set;}
        [Required]
        public string Phone { get;set;}
        [Required]
        [Display(Name ="Mobile Number")]
        public string MobileNumber { get;set;}
        [Required]
        public double Nid { get;set;}
    }
}
