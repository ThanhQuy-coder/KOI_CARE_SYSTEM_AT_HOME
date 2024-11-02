// YourDbContext.cs
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

    public DbSet<Article> Articles { get; set; } // Bảng bài viết
    public DbSet<Category> Categories { get; set; } // Bảng danh mục
    public DbSet<Comment> Comments { get; set; } // Bảng bình luận
    public DbSet<Product> Products { get; set; } // Bảng sản phẩm
    public DbSet<User> Users { get; set; } // Bảng người dùng
    public DbSet<FeedingSchedule> FeedingSchedules { get; set; } // Bảng lịch cho ăn
    public DbSet<KoiFish> KoiFishes { get; set; } // Bảng cá koi
    public DbSet<Pond> Ponds { get; set; } // Bảng ao
    public DbSet<WaterParameter> WaterParameters { get; set; } // Bảng thông số nước
    public DbSet<SaltCalculation> SaltCalculations { get; set; } // Bảng tính toán muối

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Thêm các mối quan hệ hoặc cấu hình cho các bảng

        modelBuilder.Entity<Article>()
            .HasOne(a => a.Category)
            .WithMany(c => c.Articles)
            .HasForeignKey(a => a.CategoryId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Article)
            .WithMany(a => a.Comments)
            .HasForeignKey(c => c.ArticleId);

        // Bạn có thể thêm các cấu hình quan hệ khác nếu cần cho các bảng còn lại
    }
}
