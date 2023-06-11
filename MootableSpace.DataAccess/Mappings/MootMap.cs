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
    public class MootMap : IEntityTypeConfiguration<Moot>
    {
        public void Configure(EntityTypeBuilder<Moot> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Picture).HasMaxLength(255);
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.CategoryId).IsRequired();
            // herkes, circle, sadece ben
            builder.Property(m => m.ShareStatus).IsRequired();
            builder.Property(m => m.AgreeCount).IsRequired();
            builder.Property(m => m.ViewCount).IsRequired();
            builder.Property(m => m.CommentCount).IsRequired();
            builder.Property(m => m.Text).IsRequired();
            builder.Property(m => m.Text).HasMaxLength(500);

            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("Moots");
        }
    }
}
