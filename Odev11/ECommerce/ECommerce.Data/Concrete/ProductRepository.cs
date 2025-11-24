using System;
using ECommerce.Data.Abstract;
using ECommerce.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Concrete;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ECommerceDbContext context):base(context)
    {
        
    }
    public async Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold)
    {
        var result = await _context
            .Products
            .Where(p=>p.StockQuantity<threshold)
            .ToListAsync();
        return result;
    }
}
