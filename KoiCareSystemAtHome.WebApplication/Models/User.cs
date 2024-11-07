using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.WebApplication.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Roled { get; set; }

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
