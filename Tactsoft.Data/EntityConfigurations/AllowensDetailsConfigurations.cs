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
    public class AllowensDetailsConfigurations : IEntityTypeConfiguration<AllowensDetails>
    {
        public void Configure(EntityTypeBuilder<AllowensDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.SalarySetup).WithMany(x=>x.AllowensDetailss).HasForeignKey(x=>x.SalarySetupId);
            builder.HasOne(x=>x.Allowens).WithMany(x=>x.AllowensDetailss).HasForeignKey(x=>x.AllowensId);
        }
    }
}
