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
    public class ServiceInformationConfigurations : IEntityTypeConfiguration<ServiceInformation>
    {
        public void Configure(EntityTypeBuilder<ServiceInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.ServiceInformations).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.Department).WithMany(x => x.ServiceInformations).HasForeignKey(x => x.DepertmentId);
            builder.HasOne(x => x.Designation).WithMany(x => x.ServiceInformations).HasForeignKey(x => x.DesignationId);
        }
    }
}
