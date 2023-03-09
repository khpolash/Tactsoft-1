using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class MaritialStatusConfigurations : IEntityTypeConfiguration<MaritialStatus>
    {
        public void Configure(EntityTypeBuilder<MaritialStatus> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
