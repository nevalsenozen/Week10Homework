using System;
using ECommerce.Data.Models.Abstract;

namespace ECommerce.Data.Models;

public class Product : BaseClass
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}


