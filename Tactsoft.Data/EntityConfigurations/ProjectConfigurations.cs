using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tactsoft.Core.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tactsoft.Data.EntityConfigurations
{
    internal class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CompanyInfo).WithMany(x => x.Projects).HasForeignKey(x => x.CompanyInfoId);
            builder.HasOne(x=>x.BranchInfo).WithMany(x=>x.Projects).HasForeignKey(x => x.BranchInfoId);
        }
    }
}
