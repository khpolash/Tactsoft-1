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
    public class EmploymentHistoryConfigurations : IEntityTypeConfiguration<EmploymentHistory>
    {
        public void Configure(EntityTypeBuilder<EmploymentHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.EmploymentHistorys).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.Designation).WithMany(x => x.EmploymentHistorys).HasForeignKey(x => x.DesignationId);
        }
    }
}
