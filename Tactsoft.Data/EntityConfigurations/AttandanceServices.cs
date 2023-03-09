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
    public class AttandanceServices : IEntityTypeConfiguration<Attandance>
    {
        public void Configure(EntityTypeBuilder<Attandance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.Attandances).HasForeignKey(x=>x.EmployeeId);
        }
    }
}
