using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using mootableProject.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Data.Concrete.Mappings
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.Message).IsRequired();
            builder.Property(l => l.Message).HasMaxLength(255);
            builder.Property(l => l.LogStatus).IsRequired();
            builder.Property(l => l.ModifiedById).IsRequired();
            builder.Property(l => l.ModifiedDate).IsRequired();
            builder.Property(l => l.IsDeleted).IsRequired();
            builder.ToTable("Logs");
        }
    }
}
