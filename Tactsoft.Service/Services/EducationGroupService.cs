using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class EducationGroupService : BaseService<EducationGroup>,IEducationGroupService
    {
        private readonly AppDbContext _context;
        public EducationGroupService(AppDbContext context) : base(context)
        {
            this._context= context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.EducationGroupName, Value = x.Id.ToString() });
        }
    }
}
