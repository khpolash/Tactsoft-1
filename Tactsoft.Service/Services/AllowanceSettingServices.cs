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
    public class AllowanceSettingServices : BaseService<AllowanceSetting>,IAllowanceSettingServices
    {
        private readonly AppDbContext _Context;
        public AllowanceSettingServices(AppDbContext context) : base(context)
        {
            this._Context= context;
        }
       }
}
