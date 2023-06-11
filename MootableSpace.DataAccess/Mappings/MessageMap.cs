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
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            //gönderen user'ın id si Required mi?
            builder.Property(m => m.SenderId).IsRequired();
            builder.Property(m => m.Picture).HasMaxLength(250);
            builder.Property(m => m.Text).IsRequired();
            builder.Property(m => m.Text).HasMaxLength(255);

            builder.Property(m => m.ModifiedById).IsRequired();
            builder.Property(m => m.ModifiedDate).IsRequired();
            builder.Property(m => m.IsDeleted).IsRequired();

            builder.ToTable("Messages");
        }
    }
}
