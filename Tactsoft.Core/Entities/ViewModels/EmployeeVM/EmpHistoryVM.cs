using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities.ViewModels.EmployeeVM
{
    public class EmpHistoryVM : MasterEntity
    {

        public string NameOfCompany { get; set; }

        public string Designation { get; set; }

        public DateTime JobFor { get; set; }

        public DateTime JobTo { get; set; }

        public Double Salary { get; set; }
        public string ReasonForLeaving { get; set; }
    }
}
