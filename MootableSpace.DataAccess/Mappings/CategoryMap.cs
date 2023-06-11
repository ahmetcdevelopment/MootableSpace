using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MootableSpace.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.DataAccess.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {/// <summary>
     /// Category'e sınıfına ait yapılandırmam.
     /// </summary>
     /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(100);
            builder.Property(c => c.ModifiedById).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Felsefe",
                    Description = "Felsefe Kategorisi",
                    ModifiedById = 1,
                    ModifiedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Category
                {
                    Id = 2,
                    Name = "Siyaset",
                    Description = "Siyaset Kategorisi",
                    ModifiedById = 1,
                    ModifiedDate = DateTime.Now,
                    IsDeleted = false,
                }
                );
        }
    }
}
