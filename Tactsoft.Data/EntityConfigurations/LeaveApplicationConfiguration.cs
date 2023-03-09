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
    public class LeaveApplicationConfiquration : IEntityTypeConfiguration<LeaveApplication>
    {
        public void Configure(EntityTypeBuilder<LeaveApplication> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee).WithMany(x => x.LeaveApplications).HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.LeaveType).WithMany(x => x.LeaveApplications).HasForeignKey(x => x.LeaveTypeId);
            
        }
    }
}
