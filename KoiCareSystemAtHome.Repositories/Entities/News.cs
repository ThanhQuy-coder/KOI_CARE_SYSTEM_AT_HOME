using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class News
{
    public Guid PostId { get; set; }

    public string Author { get; set; } = null!;

    public string? Title { get; set; }

    public string Content { get; set; } = null!;

    public DateTime PublishDate { get; set; }
}
