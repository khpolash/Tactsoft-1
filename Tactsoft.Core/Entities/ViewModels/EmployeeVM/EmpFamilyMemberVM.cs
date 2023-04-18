using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities.ViewModels.EmployeeVM
{
    public class EmpFamilyMemberVM : MasterEntity
    {
        public string FamilyMemberName { get; set; }

        public string RelationShip { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }
    }
}
