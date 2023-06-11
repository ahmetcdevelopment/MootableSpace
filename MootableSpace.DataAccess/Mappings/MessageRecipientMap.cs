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
    public class MessageRecipientMap : IEntityTypeConfiguration<MessageRecipient>
    {
        public void Configure(EntityTypeBuilder<MessageRecipient> builder)
        {
            builder.HasKey(mr => mr.Id);
            builder.Property(mr => mr.Id).ValueGeneratedOnAdd();
            builder.Property(mr => mr.MessageId).IsRequired();
            builder.Property(mr => mr.RecipientId).IsRequired();
            //okundu veya okunmadı olarak kesin belirlenmesi gerekiyor.
            builder.Property(mr => mr.IsShow).IsRequired();

            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.ToTable("MessageRecipients");
        }
    }
}
