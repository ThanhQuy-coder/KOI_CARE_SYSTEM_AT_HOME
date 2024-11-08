using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class Account
{
    public int AccountId { get; set; }

    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PassWorkHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
