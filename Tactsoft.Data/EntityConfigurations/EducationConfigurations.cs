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
    internal class EducationConfigurations : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.Educations).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.Degree).WithMany(x => x.Educations).HasForeignKey(x => x.DegreeId);
            builder.HasOne(x => x.EducationGroup).WithMany(x => x.Educations).HasForeignKey(x => x.EducationGroupId);
        }
    }
}
