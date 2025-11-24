using System;
using ECommerce.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Ürün Bilgileri
        List<Product> products = [
            new Product{Id=1, Name="IPhone 16", Price=60000, StockQuantity=6, CreatedAt=new DateTime(2025,11,19),ModifiedAt=new DateTime(2025,11,19)},
            new Product{Id=2, Name="IPhone 15", Price=50000, StockQuantity=16, CreatedAt=new DateTime(2025,11,19),ModifiedAt=new DateTime(2025,11,19)},
            new Product{Id=3, Name="IPhone 14", Price=40000, StockQuantity=26, CreatedAt=new DateTime(2025,11,19),ModifiedAt=new DateTime(2025,11,19)},
            new Product{Id=4, Name="IPhone 13", Price=30000, StockQuantity=36, CreatedAt=new DateTime(2025,11,19),ModifiedAt=new DateTime(2025,11,19)},
            new Product{Id=5, Name="IPhone 12", Price=20000, StockQuantity=46, CreatedAt=new DateTime(2025,11,19),ModifiedAt=new DateTime(2025,11,19)}
        ];
        modelBuilder.Entity<Product>().HasData(products);
        #endregion
    }
}
