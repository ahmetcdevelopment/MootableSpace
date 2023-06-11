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
    public class MootableMap : IEntityTypeConfiguration<Mootable>
    {
        public void Configure(EntityTypeBuilder<Mootable> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.CategoryId).IsRequired();
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(255);

            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.ToTable("Mootables");
        }
    }
}
