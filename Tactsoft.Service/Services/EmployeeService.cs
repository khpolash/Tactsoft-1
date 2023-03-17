
using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class EmployeeService : BaseService<Employee>,IEmployeeService
    {
        private readonly AppDbContext _Context;
        public EmployeeService(AppDbContext context) : base(context)
        {
            this._Context = context;
        }
 
        IEnumerable<Employee> IEmployeeService.AllByDepertmentId(int deptId)
        {
            if (deptId == 0)
                return All();
            return All().Where(x => x.DepartmentId == deptId);
        }

        IEnumerable<SelectListItem> IEmployeeService.Dropdown()
        {
            
            return All().Select(x => new SelectListItem { Text = x.FirstName, Value = x.Id.ToString() });
        }

        string IEmployeeService.NameById(long id)
        {
            var emp = Find(id);
            return emp.FirstName + " " + emp.MiddleName + " " + emp.LastName;
        }
    }
}
