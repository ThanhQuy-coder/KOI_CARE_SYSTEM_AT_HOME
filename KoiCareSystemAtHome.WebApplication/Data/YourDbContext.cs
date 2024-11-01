using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
    {
    }

    // Định nghĩa các DbSet cho các bảng trong cơ sở dữ liệu
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    // Thêm các DbSet khác cho các bảng khác
}
