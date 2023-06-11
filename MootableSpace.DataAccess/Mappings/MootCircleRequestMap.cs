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
    public class MootCircleRequestMap : IEntityTypeConfiguration<MootCircle>
    {
        public void Configure(EntityTypeBuilder<MootCircle> builder)
        {
            builder.HasKey(mcr => mcr.Id);
            builder.Property(mcr => mcr.Id).ValueGeneratedOnAdd();
            builder.Property(mcr => mcr.UserId).IsRequired();
            builder.Property(mcr => mcr.UserId2).IsRequired();
            //arkadaşlık isteği yoksayılırsa bu işaretlenecek.
            builder.Property(mcr => mcr.IsShow).IsRequired();

            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("MoorCircleRequests");
        }
    }
}
