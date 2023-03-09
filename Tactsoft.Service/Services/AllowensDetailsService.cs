﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class AllowensDetailsService : BaseService<AllowensDetails>,IAllowensDetailsService
    {
        private readonly AppDbContext _context;
        public AllowensDetailsService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        
        
    }
}
