using System;

namespace ECommerce.Data.Models.Abstract;

public abstract class BaseClass
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
}
