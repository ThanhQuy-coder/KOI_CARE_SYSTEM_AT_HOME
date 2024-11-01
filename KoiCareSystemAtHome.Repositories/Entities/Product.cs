using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class Product
{
    public string? UserId { get; set; }

    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ImageProduct { get; set; } = null!;

    public double Price { get; set; }

    public string Desciption { get; set; } = null!;

    public string ProductType { get; set; } = null!;

    public DateTime DatePlace { get; set; }

    public virtual User? User { get; set; }
}
