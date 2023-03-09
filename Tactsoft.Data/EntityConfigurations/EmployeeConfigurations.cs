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
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Religion).WithMany(x=>x.Employees).HasForeignKey(x=>x.ReligionId);
            
            builder.HasOne(x => x.MaritialStatus).WithMany(x => x.Employees).HasForeignKey(x => x.MaritialStatusId);
            builder.HasOne(x => x.CompanyInfo).WithMany(x => x.Employees).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.BranchInfo).WithMany(x => x.Employees).HasForeignKey(x => x.BrancehId);
            builder.HasOne(x => x.project).WithMany(x => x.Employees).HasForeignKey(x => x.ProjectId);
            builder.HasOne(x => x.Gender).WithMany(x => x.Employees).HasForeignKey(x => x.GenderId);
        }
    }
}
