using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class UserProfile
{
    public Guid UserId { get; set; }

    public Guid AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Gender { get; set; }

    public string Role { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
