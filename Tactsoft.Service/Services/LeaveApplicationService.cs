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
    public class LeaveApplictionService : BaseService<LeaveApplication>, ILeaveApplictionService
    {
        private readonly AppDbContext _context;

        public LeaveApplictionService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
