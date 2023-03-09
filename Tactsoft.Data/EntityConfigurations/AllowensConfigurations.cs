using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class AllowensConfigurations : IEntityTypeConfiguration<Allowens>
    {
        public void Configure(EntityTypeBuilder<Allowens> builder)
        {
           builder.HasKey(x => x.Id);
        }
    }
}
