using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class Account
{
    public Guid AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string PassWorkHash { get; set; } = null!;

    public string Email { get; set; } = null!;
}
