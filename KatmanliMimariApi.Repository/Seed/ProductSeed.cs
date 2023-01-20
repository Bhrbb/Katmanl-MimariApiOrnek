using KatmanlıMimariApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariApi.Repository.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            { Id = 1, Name = "Kalem1", CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now });
            builder.HasData(new Product
            { Id = 2, Name = "Kitap1", CategoryId = 3, Price = 600, Stock = 10, CreatedDate = DateTime.Now });
            builder.HasData(new Product
            { Id = 3, Name = "Defter", CategoryId = 2, Price = 60, Stock = 20, CreatedDate = DateTime.Now });
            builder.HasData(new Product
            { Id = 4, Name = "Kitap2", CategoryId = 3, Price = 100, Stock = 20, CreatedDate = DateTime.Now });



        }
    }
}
