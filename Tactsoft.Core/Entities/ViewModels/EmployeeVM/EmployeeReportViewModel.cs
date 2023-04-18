using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tactsoft.Core.Entities.ViewModels.EmployeeVM
{
    public class EmployeeReportViewModel
    {
        public EmpBasicInfoVM EmpBasicInfoVM { get; set; }
        public EmpFamilyMemberVM EmpFamilyMemberVM { get; set; }
        public EmpHistoryVM EmpHistoryVM { get; set; }
    }
}
