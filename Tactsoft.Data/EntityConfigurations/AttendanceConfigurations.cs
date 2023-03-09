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
    public class AttendanceConfigurations : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.Attendances).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.CompanyInfo).WithMany(x => x.Attendances).HasForeignKey(x => x.CompanyInfoId);
            builder.HasOne(x => x.BranchInfo).WithMany(x => x.Attendances).HasForeignKey(x => x.BranchInfoId);
        }
    }
}
