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
    public class MootableSubscriberMap : IEntityTypeConfiguration<MootableSubscriber>
    {
        public void Configure(EntityTypeBuilder<MootableSubscriber> builder)
        {
            builder.HasKey(ms => ms.Id);
            builder.Property(ms => ms.Id).ValueGeneratedOnAdd();
            builder.Property(ms => ms.UserId).IsRequired();
            builder.Property(ms => ms.MootableId).IsRequired();

            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("MootableSubscribers");
        }
    }
}
