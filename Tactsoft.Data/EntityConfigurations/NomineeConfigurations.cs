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
    public class NomineeConfigurations : IEntityTypeConfiguration<Nominee>
    {
        public void Configure(EntityTypeBuilder<Nominee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.Nominees).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.RelationShip).WithMany(x => x.Nominees).HasForeignKey(x => x.RelationShipId);
        }
    }
}
