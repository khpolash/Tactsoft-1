using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities.ViewModels
{
    public class EmploymentHistoryViewModel:MasterEntity
    {
      
   
   
        public string NameOfCompany { get; set; }
        public DateTime JobFor { get; set; }
        public long Designation { get; set; }

        public DateTime JobTo { get; set; }
      
        public Double Salary { get; set; }
       
        public string ReasonForLeaving { get; set; }

    
    }
}
