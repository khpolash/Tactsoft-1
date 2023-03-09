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
    public class AttandanceService : BaseService<Attandance>,IAttandanceService
    {
        private readonly AppDbContext _Context;
        public AttandanceService(AppDbContext context) : base(context)
        {
            this._Context = context;
        }
    }
}
