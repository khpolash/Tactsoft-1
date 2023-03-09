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
    internal class ServiceInfoConfigurations : IEntityTypeConfiguration<ServiceInfo>
    {
        public void Configure(EntityTypeBuilder<ServiceInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.ServiceInfos).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.Department).WithMany(x => x.ServiceInfos).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.Designation).WithMany(x => x.ServiceInfos).HasForeignKey(x => x.DesignationId);
            builder.HasOne(x => x.BranchInfo).WithMany(x => x.ServiceInfos).HasForeignKey(x => x.BranchId);
        }
    }
}
