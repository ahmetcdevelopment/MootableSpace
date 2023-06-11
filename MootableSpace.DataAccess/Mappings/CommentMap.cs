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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        /// <summary>
        /// Comment'e ait yapılandırmam.
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.MootId).IsRequired();
            builder.Property(c => c.ParentId).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.AgreeCount).IsRequired();
            builder.Property(c => c.ViewCount).IsRequired();
            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(255);

            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("Comments");
        }
    }
}
