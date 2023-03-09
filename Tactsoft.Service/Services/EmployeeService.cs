
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
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.FristName,Value = x.Id.ToString() });
        }

    }
}
