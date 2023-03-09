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
    internal class RelationShipConfigurations : IEntityTypeConfiguration<RelationShip>
    {
        public void Configure(EntityTypeBuilder<RelationShip> builder)
        {
            builder.HasKey(x => x.Id);
            
        }
    }
}
