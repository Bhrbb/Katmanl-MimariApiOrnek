using KatmanlıMimariApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariApi.Repository.Seed
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                            new Category { Id = 1, Name = "Kalem" },
                            new Category { Id = 2, Name = "Defter" },
                            new Category { Id = 3, Name = "Kitap" });
            
        }
    }
}
