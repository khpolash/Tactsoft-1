﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class AdvanceTypeConfigurations : IEntityTypeConfiguration<AdvanceType>
    {
        public void Configure(EntityTypeBuilder<AdvanceType> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
