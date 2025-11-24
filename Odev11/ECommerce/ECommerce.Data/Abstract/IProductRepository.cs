using System;
using ECommerce.Data.Models;

namespace ECommerce.Data.Abstract;

public interface IProductRepository: IRepository<Product>
{
    Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold);
}
