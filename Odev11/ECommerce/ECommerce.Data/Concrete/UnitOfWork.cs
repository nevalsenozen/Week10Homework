using System;
using ECommerce.Data.Abstract;

namespace ECommerce.Data.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly ECommerceDbContext _context;

    public IProductRepository Products { get; private set; }

    public ICustomerRepository Customers {get; private set; }
    public UnitOfWork(ECommerceDbContext context)
    {
        _context = context;
        Products = new ProductRepository(_context);
        Customers = new CustomerRepository(_context);
    }

    public async Task<int> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
