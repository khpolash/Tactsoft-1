
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
    internal class BranchInfoConfigurations : IEntityTypeConfiguration<BranchInfo>
    {
        public void Configure(EntityTypeBuilder<BranchInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.CompanyInfo).WithMany(x=>x.BranchInfos).HasForeignKey(x=>x.CompanyInfoId);
            builder.HasOne(x => x.Country).WithMany(x => x.BranchInfos).HasForeignKey(x => x.CountryId);
            builder.HasOne(x=>x.State).WithMany(x=>x.BranchInfos).HasForeignKey(x=>x.StateId);
            builder.HasOne(x => x.City).WithMany(x => x.BranchInfos).HasForeignKey(x => x.CityId);
            builder.HasOne(x => x.ZipCode).WithMany(x => x.BranchInfos).HasForeignKey(x => x.ZipCodeId);
        }
    }
}
