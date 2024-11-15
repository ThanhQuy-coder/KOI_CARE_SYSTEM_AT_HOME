using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class User
{
    public Guid? AccountId { get; set; }

    public Guid UserId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; }

    public string Role { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
