using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class AllowanceSetupService : BaseService<AllowanceSetup>,IAllowanceSetupService
    {
        private AppDbContext _appDbContext;
        public AllowanceSetupService(AppDbContext context) : base(context)
        {
            this._appDbContext = context;
        }
    }
}
