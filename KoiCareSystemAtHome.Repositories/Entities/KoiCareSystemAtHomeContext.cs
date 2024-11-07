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

    public virtual DbSet<FeedingSchedule> FeedingSchedules { get; set; }

    public virtual DbSet<Koifish> Koifishes { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SaltCalculation> SaltCalculations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WarterParameter> WarterParameters { get; set; }

  //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
     //   => optionsBuilder.UseSqlServer("Data Source=THANHQUY;Initial Catalog=KoiCareSystemAtHome;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FeedingSchedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FEEDING_SCHEDULE");

            entity.Property(e => e.FeedingTime)
                .HasColumnType("datetime")
                .HasColumnName("feedingTime");
            entity.Property(e => e.FishId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fishID");
            entity.Property(e => e.FoodType)
                .HasMaxLength(100)
                .HasColumnName("foodType");
            entity.Property(e => e.RequiredFoodAmount).HasColumnName("requiredFoodAmount");

            entity.HasOne(d => d.Fish).WithMany()
                .HasForeignKey(d => d.FishId)
                .HasConstraintName("FK__FEEDING_S__fishI__3F466844");
        });

        modelBuilder.Entity<Koifish>(entity =>
        {
            entity.HasKey(e => e.FishId).HasName("PK__KOIFISH__5222DA39E2A0FE5A");

            entity.ToTable("KOIFISH");

            entity.Property(e => e.FishId)
                .HasMaxLength(10)
                .IsUnicode(false)
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
            entity.Property(e => e.PondId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PondID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.WeightFish).HasColumnName("weightFish");

            entity.HasOne(d => d.Pond).WithMany(p => p.Koifishes)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__KOIFISH__PondID__3D5E1FD2");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__NEWS__DD0C73BA57111B51");

            entity.ToTable("NEWS");

            entity.HasIndex(e => e.Author, "UQ__NEWS__C2E6DB674A282B92").IsUnique();

            entity.Property(e => e.PostId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("postID");
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
            entity.HasKey(e => e.PondId).HasName("PK__POND__D18BF8542B307F92");

            entity.ToTable("POND");

            entity.Property(e => e.PondId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PondID");
            entity.Property(e => e.Depth).HasColumnName("depth");
            entity.Property(e => e.DrainCount).HasColumnName("drainCount");
            entity.Property(e => e.ImagePond).HasColumnName("imagePond");
            entity.Property(e => e.NamePond).HasMaxLength(10);
            entity.Property(e => e.PumpCapacity).HasColumnName("pumpCapacity");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.User).WithMany(p => p.Ponds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__POND__UserId__3A81B327");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK___PRODUCT__2D10D14A6946EC55");

            entity.ToTable("_PRODUCT");

            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("productID");
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
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK___PRODUCT__UserId__45F365D3");
        });

        modelBuilder.Entity<SaltCalculation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SALT_CALCULATION");

            entity.Property(e => e.CalculationTime)
                .HasColumnType("datetime")
                .HasColumnName("calculationTime");
            entity.Property(e => e.PondId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PondID");
            entity.Property(e => e.RequiredSaltAmount).HasColumnName("requiredSaltAmount");

            entity.HasOne(d => d.Pond).WithMany()
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__SALT_CALC__PondI__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK___USER__1788CC4C53DEA5C4");

            entity.ToTable("_USER");

            entity.HasIndex(e => e.Email, "UQ___USER__A9D10534C1E9F70D").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(255)
                .HasColumnName("passwordUser");
            entity.Property(e => e.Roled).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<WarterParameter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WARTER_PARAMETER");

            entity.Property(e => e.MeasurementTime)
                .HasColumnType("datetime")
                .HasColumnName("measurementTime");
            entity.Property(e => e.Nitrate).HasColumnName("nitrate");
            entity.Property(e => e.Nitrie).HasColumnName("nitrie");
            entity.Property(e => e.Oxygen).HasColumnName("oxygen");
            entity.Property(e => e.PH).HasColumnName("pH");
            entity.Property(e => e.Phospate).HasColumnName("phospate");
            entity.Property(e => e.PondId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PondID");
            entity.Property(e => e.SaltLevel).HasColumnName("saltLevel");
            entity.Property(e => e.Temperature).HasColumnName("temperature");

            entity.HasOne(d => d.Pond).WithMany()
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__WARTER_PA__PondI__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
