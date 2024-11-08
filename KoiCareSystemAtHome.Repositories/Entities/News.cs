using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class News
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostId { get; set; }

    public string Author { get; set; } = null!;

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime PublishDate { get; set; }
}
