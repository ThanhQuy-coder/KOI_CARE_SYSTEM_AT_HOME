using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class KoiCareSystemAtHomeContext : DbContext
{
    public KoiCareSystemAtHomeContext()
    {
    }

    public KoiCareSystemAtHomeContext(DbContextOptions<KoiCareSystemAtHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<FeedingSchedule> FeedingSchedules { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SaltCalculation> SaltCalculations { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<WaterParameter> WaterParameters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ_Account_Email").IsUnique();

            entity.HasIndex(e => e.Username, "UQ_Account_Username").IsUnique();

            entity.Property(e => e.AccountId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("AccountID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<FeedingSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId);

            entity.Property(e => e.ScheduleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ScheduleID");
            entity.Property(e => e.FeedingTime).HasColumnType("datetime");
            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.FoodType).HasMaxLength(100);
            entity.Property(e => e.RequiredFoodAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Fish).WithMany(p => p.FeedingSchedules)
                .HasForeignKey(d => d.FishId)
                .HasConstraintName("FK_FeedingSchedules_KoiFishes");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.FishId);

            entity.HasIndex(e => e.PondId, "IX_KoiFishes_PondID");

            entity.Property(e => e.FishId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("FishID");
            entity.Property(e => e.BodyShape).HasMaxLength(50);
            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.FishLocation).HasMaxLength(100);
            entity.Property(e => e.FishName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Size).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pond).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_KoiFishes_Ponds");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.PostId);

            entity.Property(e => e.PostId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PostID");
            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.PublishDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Ponds_UserID");

            entity.Property(e => e.PondId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PondID");
            entity.Property(e => e.Depth).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PondName).HasMaxLength(100);
            entity.Property(e => e.PumpCapacity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.Ponds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Ponds_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ProductID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductType).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Products_User");
        });

        modelBuilder.Entity<SaltCalculation>(entity =>
        {
            entity.HasKey(e => e.CalculationId);

            entity.Property(e => e.CalculationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CalculationID");
            entity.Property(e => e.CalculationTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.RequiredSaltAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pond).WithMany(p => p.SaltCalculations)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_SaltCalculations_Ponds");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.HasIndex(e => e.AccountId, "IX_UserProfiles_AccountID");

            entity.HasIndex(e => e.AccountId, "UQ_UserProfile_AccountID").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("User");

            entity.HasOne(d => d.Account).WithOne(p => p.UserProfile)
                .HasForeignKey<UserProfile>(d => d.AccountId)
                .HasConstraintName("FK_UserProfile_Account");
        });

        modelBuilder.Entity<WaterParameter>(entity =>
        {
            entity.HasKey(e => e.ParameterId);

            entity.HasIndex(e => e.PondId, "IX_WaterParameters_PondID");

            entity.Property(e => e.ParameterId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ParameterID");
            entity.Property(e => e.MeasurementTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nitrate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Nitrite).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Oxygen).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Ph)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("PH");
            entity.Property(e => e.Phosphate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.SaltLevel).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Temperature).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Pond).WithMany(p => p.WaterParameters)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_WaterParameters_Ponds");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
