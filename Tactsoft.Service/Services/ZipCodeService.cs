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
    public class ZipCodeService : BaseService<ZipCode>, IZipCodeService
    {
        private readonly AppDbContext _Context;
        public ZipCodeService(AppDbContext context) : base(context)
        {
            this._Context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x=>new SelectListItem { Text=x.ZipCodeName, Value=x.Id.ToString() });   
        }
    }
}
