using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public Guid? UserId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public string ProductType { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual UserProfile? User { get; set; }
}
