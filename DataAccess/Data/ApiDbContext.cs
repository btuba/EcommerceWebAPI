using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Product
            modelBuilder.Entity<Product>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>().HasMany(p => p.Sizes);
            modelBuilder.Entity<Product>().HasMany(p => p.Colors);
            modelBuilder.Entity<Product>().HasMany(p => p.Images);
            #endregion

            #region Category
            modelBuilder.Entity<Category>().Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Category>().HasMany(c => c.SubCategories)
                .WithOne(c => c.SubCategory)
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Color
            modelBuilder.Entity<Color>().Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Color>().HasMany(c => c.Images)
                .WithOne(i => i.Color)
                .HasForeignKey(i => i.ColorId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Size
            modelBuilder.Entity<Size>().Property(s => s.Data)
                .IsRequired()
                .HasMaxLength(25);
            #endregion

            #region Image
            modelBuilder.Entity<Image>().Property(i => i.Url)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Image>().HasOne(i => i.Color)
                .WithMany(c => c.Images)
                .HasForeignKey(i => i.ColorId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Inventory
            modelBuilder.Entity<Inventory>().Property(i => i.ProductId)
                .IsRequired();

           // modelBuilder.Entity<Inventory>()
            #endregion


            modelBuilder.Entity<Size>().HasData(
                new Size { Id = 1, Data = "S" },
                new Size { Id = 2, Data = "M" },
                new Size { Id = 3, Data = "L" },
                new Size { Id = 4, Data = "36" },
                new Size { Id = 5, Data = "37" },
                new Size { Id = 6, Data = "38" },
                new Size { Id = 7, Data = "39" },
                new Size { Id = 8, Data = "41" },
                new Size { Id = 9, Data = "42" },
                new Size { Id = 10, Data = "43" },
                new Size { Id = 11, Data = "44" }
                );

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Kırmızı"},
                new Color { Id = 2, Name = "Mavi"},
                new Color { Id = 3, Name = "Siyah"},
                new Color { Id = 4, Name = "Beyaz"}
                );

            /*modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Kadın",
                    SubCategories = new List<Category> {
                        new Category
                        {
                            Id = 2,
                            Name = "Üst" ,
                            SupCategoryId = 1,
                            SubCategories = new List<Category>
                            {
                                new Category
                                {
                                    Id=3,
                                    Name="Tişört",
                                    SupCategoryId=2,
                                },
                                new Category
                                {
                                    Id=4,
                                    Name="Bluz",
                                    SupCategoryId=2,
                                    SubCategories=new List<Category>
                                    {
                                        new Category{Id=5, Name="Askılı", SupCategoryId = 4},
                                        new Category{Id=6, Name="Uzun kollu", SupCategoryId = 4}
                                    }
                                }
                            }
                        },
                        new Category
                        {
                            Id = 7,
                            Name ="Etek" ,
                            SupCategoryId = 1,
                            SubCategories = new List<Category>
                            {
                                new Category
                                {
                                    Id=8, Name="Çan Etek",
                                    SupCategoryId = 7
                                },
                                new Category
                                {
                                    Id=9, Name="Mini Etek",
                                    SupCategoryId = 7
                                }
                            }
                        },
                        new Category { Id = 10, Name ="Ayakkabı" , SupCategoryId = 1},
                    }
                },
                new Category
                {
                    Id = 11,
                    Name = "Erkek",
                    SubCategories = new List<Category> {
                        new Category
                        {
                            Id = 12, Name = "Tişört ve Atlet",
                            SupCategoryId = 11,
                            SubCategories = new List<Category>
                            {
                                new Category{Id = 13, Name="Atlet", SupCategoryId=12},
                                new Category{Id=14, Name="Tişört", SupCategoryId =12},
                                new Category{Id=15, Name="Basic",SupCategoryId=12}
                            }
                        },
                        new Category { Id = 16, Name ="Ayakkabı" , SupCategoryId = 12}
                    }
                }
                );
           
        }*/
    }
}
