using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MootableSpace.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.DataAccess.Mappings
{
    public class MootCircleMap : IEntityTypeConfiguration<MootCircle>
    {
        public void Configure(EntityTypeBuilder<MootCircle> builder)
        {
            builder.HasKey(mc => mc.Id);
            builder.Property(mc => mc.Id).ValueGeneratedOnAdd();
            builder.Property(mc => mc.UserId).IsRequired();
            builder.Property(mc => mc.UserId2).IsRequired();
            //engellendi bilgisi için IsShow önemlidir.
            builder.Property(mc => mc.IsShow).IsRequired();

            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("MootCircles");
        }
    }
}
