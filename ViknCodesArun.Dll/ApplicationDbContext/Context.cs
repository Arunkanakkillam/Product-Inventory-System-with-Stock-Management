    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ViknCodesArun.Dll.Models;

    namespace ViknCodesArun.Dll.ApplicationDbContext
    {
   
        public class Context: DbContext
        {
            public DbSet<Product> Products { get; set; }
            public DbSet<Variants> Variants { get; set; }
            public DbSet<SubVariants> SubVariants { get; set; }
            public Context(DbContextOptions<Context>options):base(options) 
            {

            }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Product>()
                    .HasKey(p => p.Id);

                modelBuilder.Entity<Variants>()
                    .HasKey(p => p.Id);

                modelBuilder.Entity<Variants>()
                    .HasOne(p => p.Product)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(p => p.ProductId);

                modelBuilder.Entity<SubVariants>()
                    .HasKey(p => p.Id);

                modelBuilder.Entity<SubVariants>()
                    .HasOne(p=>p.Variant)
                    .WithMany(p=>p.SubVariants)
                    .HasForeignKey(p=>p.VariantId);
                modelBuilder.Entity<Product>()
                    .Property(p => p.TotalStock)
                    .HasPrecision(18, 2);

                modelBuilder.Entity<Product>()
                    .HasIndex(p => p.ProductCode)
                    .IsUnique();
            }


        }
    }
