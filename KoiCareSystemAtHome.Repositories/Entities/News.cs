using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class News
{
    public string PostId { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime PublishDate { get; set; }
}
