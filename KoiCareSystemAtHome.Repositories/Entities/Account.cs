using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class Account
{
    public Guid AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string PassWordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
