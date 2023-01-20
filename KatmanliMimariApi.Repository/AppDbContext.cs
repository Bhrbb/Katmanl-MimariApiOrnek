using KatmanlıMimariApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariApi.Repository
{
    public  class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            //It is more correct to add as dependent on the product
            //var p= new Product()
            //{
            //    ProductFeature= new ProductFeature()
            //    {

            //    }
            //}
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }//add independently
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //find configuration folders in repository and apply
            //if you want to do  one by one so do
            // modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 100,
                ProductId = 1,
            }, new ProductFeature()
            {
                Id = 2,
                Color = "Kırmızı",
                Height = 100,
                Width = 100,
                ProductId = 2
            });
            //can also be done here(Repository-->Seed)
            //but not avaible

            base.OnModelCreating(modelBuilder);
        }
    }
}
