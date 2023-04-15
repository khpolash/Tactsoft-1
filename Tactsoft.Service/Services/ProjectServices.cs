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
    public class ProjectServices : BaseService<Project>,IProjectService
    {
        private readonly AppDbContext _Context;
        public ProjectServices(AppDbContext context) : base(context)
        {
            this._Context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.ProjectName, Value = x.Id.ToString() });
        }

        public string NameById(long projectId)
        {
            var Project = Find(projectId);
            return Project.ProjectName;
        }
    }
}
