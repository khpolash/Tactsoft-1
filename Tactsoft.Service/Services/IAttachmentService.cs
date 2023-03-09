﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public interface IAttachmentService:IBaseService<Attachment>
    {
        IEnumerable<SelectListItem> Dropdown();
    }
}
