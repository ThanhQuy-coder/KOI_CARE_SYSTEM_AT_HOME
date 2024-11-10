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

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WaterParameter> WaterParameters { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6OVLRPL;Initial Catalog=KoiCareSystemAtHome;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5867E2EE720");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__536C85E42CC75C69").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E6164388ECCA8").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.PassWorkHash)
                .HasMaxLength(100)
                .HasColumnName("passWorkHash");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__UserId__3C69FB99");
        });

        modelBuilder.Entity<FeedingSchedule>(entity =>
        {
            entity.HasKey(e => e.FeedingScheduleId).HasName("PK__tmp_ms_x__1B08C84566FE2361");

            entity.ToTable("FeedingSchedule");

            entity.Property(e => e.FeedingScheduleId).HasColumnName("feeding_ScheduleID");
            entity.Property(e => e.FeedingTime)
                .HasColumnType("datetime")
                .HasColumnName("feedingTime");
            entity.Property(e => e.FishId).HasColumnName("fishID");
            entity.Property(e => e.FoodType)
                .HasMaxLength(100)
                .HasColumnName("foodType");
            entity.Property(e => e.RequiredFoodAmount).HasColumnName("requiredFoodAmount");

            entity.HasOne(d => d.Fish).WithMany(p => p.FeedingSchedules)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeedingSc__fishI__4222D4EF");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.FishId).HasName("PK__tmp_ms_x__5222DA3983075FB6");

            entity.ToTable("KoiFish");

            entity.Property(e => e.FishId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("fishID");
            entity.Property(e => e.AgeFish).HasColumnName("ageFish");
            entity.Property(e => e.BodyShape)
                .HasMaxLength(30)
                .HasColumnName("bodyShape");
            entity.Property(e => e.Breed)
                .HasMaxLength(50)
                .HasColumnName("breed");
            entity.Property(e => e.FishLocation).HasColumnName("fishLocation");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.ImageFish).HasColumnName("imageFish");
            entity.Property(e => e.NameFish)
                .HasMaxLength(20)
                .HasColumnName("nameFish");
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .HasColumnName("origin");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.WeightFish).HasColumnName("weightFish");

            entity.HasOne(d => d.Pond).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KoiFish__PondID__4316F928");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__News__DD0C73BAECAE2A01");

            entity.HasIndex(e => e.Author, "UQ__News__C2E6DB67FC078D8F").IsUnique();

            entity.Property(e => e.PostId).HasColumnName("postID");
            entity.Property(e => e.Author)
                .HasMaxLength(20)
                .HasColumnName("author");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.PublishDate)
                .HasColumnType("datetime")
                .HasColumnName("publishDate");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PK__Pond__D18BF854B174921F");

            entity.ToTable("Pond");

            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.Depth).HasColumnName("depth");
            entity.Property(e => e.DrainCount).HasColumnName("drainCount");
            entity.Property(e => e.ImagePond).HasColumnName("imagePond");
            entity.Property(e => e.NamePond).HasMaxLength(10);
            entity.Property(e => e.PumpCapacity).HasColumnName("pumpCapacity");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.User).WithMany(p => p.Ponds)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pond__UserId__267ABA7A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK___Product__2D10D14ACAF17F73");

            entity.ToTable("_Product");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.DatePlace)
                .HasColumnType("datetime")
                .HasColumnName("datePlace");
            entity.Property(e => e.Desciption)
                .HasColumnType("ntext")
                .HasColumnName("desciption");
            entity.Property(e => e.ImageProduct).HasColumnName("imageProduct");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("productName");
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .HasColumnName("productType");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK___Product__UserId__34C8D9D1");
        });

        modelBuilder.Entity<SaltCalculation>(entity =>
        {
            entity.HasKey(e => e.SaltCalculationId).HasName("PK__SaltCalc__69E0837880B8A2C6");

            entity.ToTable("SaltCalculation");

            entity.Property(e => e.SaltCalculationId).HasColumnName("salt_CalculationID");
            entity.Property(e => e.CalculationTime)
                .HasColumnType("datetime")
                .HasColumnName("calculationTime");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.RequiredSaltAmount).HasColumnName("requiredSaltAmount");

            entity.HasOne(d => d.Pond).WithMany(p => p.SaltCalculations)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaltCalcu__PondI__31EC6D26");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK___User__1788CC4C9F8EF44D");

            entity.ToTable("_User");

            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birthDate");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Roled).HasMaxLength(50);
        });

        modelBuilder.Entity<WaterParameter>(entity =>
        {
            entity.HasKey(e => e.WaterParameterId).HasName("PK__WaterPar__74A7C6F2CA9DE3D6");

            entity.ToTable("WaterParameter");

            entity.Property(e => e.WaterParameterId).HasColumnName("Water_ParameterID");
            entity.Property(e => e.MeasurementTime)
                .HasColumnType("datetime")
                .HasColumnName("measurementTime");
            entity.Property(e => e.Nitrate).HasColumnName("nitrate");
            entity.Property(e => e.Nitrie).HasColumnName("nitrie");
            entity.Property(e => e.Oxygen).HasColumnName("oxygen");
            entity.Property(e => e.PH).HasColumnName("pH");
            entity.Property(e => e.Phospate).HasColumnName("phospate");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.SaltLevel).HasColumnName("saltLevel");
            entity.Property(e => e.Temperature).HasColumnName("temperature");

            entity.HasOne(d => d.Pond).WithMany(p => p.WaterParameters)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__WaterPara__PondI__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
