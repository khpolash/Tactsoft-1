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
    internal class FamilyMemberConfigurations : IEntityTypeConfiguration<FamilyMember>
    {
        public void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Employee).WithMany(x=>x.FamilyMembers).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x => x.RelationShip).WithMany(x => x.FamilyMembers).HasForeignKey(x => x.RelationShipId);
        }
    }
}
