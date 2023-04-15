using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities.ViewModels
{
    public class EmployeeReportViewModel
    {
        
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public EmploymentHistoryViewModel EmploymentHistoryViewModel { get; set; }
        public FamilyMemberViewModel FamilyMemberViewModel { get; set; }
        

    }
}
