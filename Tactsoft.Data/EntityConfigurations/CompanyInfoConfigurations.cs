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
    internal class CompanyInfoConfigurations : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Country).WithMany(e => e.CompanyInfos).HasForeignKey(e => e.CountryId);
            builder.HasOne(e => e.State).WithMany(e => e.CompanyInfos).HasForeignKey(e => e.StateId);
            builder.HasOne(e => e.City).WithMany(e => e.CompanyInfos).HasForeignKey(e => e.CityId);
            builder.HasOne(e => e.ZipCode).WithMany(e => e.CompanyInfos).HasForeignKey(e => e.ZipCodeId);

        }
    }
}
