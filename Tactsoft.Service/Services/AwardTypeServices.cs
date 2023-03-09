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
    public class AwardTypeServices : BaseService<AwardType>,IAwardTypeServices
    {
        private readonly AppDbContext _Context;
        public AwardTypeServices(AppDbContext context) : base(context)
        {
            this._Context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x=>new SelectListItem { Text=x.AwardTypeName, Value=x.Id.ToString() });
        }
    }
}
