using System;
using ECommerce.Data.Abstract;
using ECommerce.Data.Models;

namespace ECommerce.Data.Concrete;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ECommerceDbContext context):base(context)
    {
        
    }
    
}
