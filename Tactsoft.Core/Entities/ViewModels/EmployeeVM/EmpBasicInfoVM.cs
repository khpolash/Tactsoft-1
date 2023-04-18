using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities.ViewModels.EmployeeVM
{
    public class EmpBasicInfoVM : MasterEntity
    {
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string NID { get; set; }
        public string Religion { get; set; }
        public string MaritialStatus { get; set; }
        public string Nationalaty { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Branceh { get; set; }
        public string Project { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
