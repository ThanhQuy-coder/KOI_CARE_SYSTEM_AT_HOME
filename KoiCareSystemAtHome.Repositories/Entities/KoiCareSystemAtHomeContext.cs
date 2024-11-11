﻿using System;
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

<<<<<<< HEAD
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6OVLRPL;Initial Catalog=KoiCareSystemAtHome;Integrated Security=True;Trust Server Certificate=True");
=======
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SOYOANON\\SQLEXPRESS;Initial Catalog=KoiCareSystemAtHome;Integrated Security=True;Trust Server Certificate=True");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5864AD078A5");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__536C85E41B250C64").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E6164B6E4246C").IsUnique();
=======
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA586C50335C9");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__536C85E4AA303EAC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E61645D4E21EB").IsUnique();
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.Property(e => e.AccountId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("AccountID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.PassWorkHash)
                .HasMaxLength(100)
                .HasColumnName("passWorkHash");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<FeedingSchedule>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.FeedingScheduleId).HasName("PK__FeedingS__1B08C845A6AC3890");
=======
            entity.HasKey(e => e.FeedingScheduleId).HasName("PK__FeedingS__1B08C8457EDE1316");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.ToTable("FeedingSchedule");

            entity.Property(e => e.FeedingScheduleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("feeding_ScheduleID");
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
<<<<<<< HEAD
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeedingSc__fishI__34C8D9D1");
=======
                .HasConstraintName("FK__FeedingSc__fishI__47DBAE45");
>>>>>>> Nhanh6(3)-BLOGANDNEWS
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.FishId).HasName("PK__KoiFish__5222DA399BBE1683");
=======
            entity.HasKey(e => e.FishId).HasName("PK__KoiFish__5222DA39EB430AC2");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

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
<<<<<<< HEAD
                .HasConstraintName("FK__KoiFish__PondID__46E78A0C");
=======
                .HasConstraintName("FK__KoiFish__PondID__440B1D61");
>>>>>>> Nhanh6(3)-BLOGANDNEWS
        });

        modelBuilder.Entity<News>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.PostId).HasName("PK__News__DD0C73BA7A55853C");

            entity.HasIndex(e => e.Author, "UQ__News__C2E6DB67A90843D4").IsUnique();
=======
            entity.HasKey(e => e.PostId).HasName("PK__News__DD0C73BAD6DC1126");

            entity.HasIndex(e => e.Author, "UQ__News__C2E6DB67F4F6E934").IsUnique();
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.Property(e => e.PostId)
                .HasDefaultValueSql("(newid())")
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
<<<<<<< HEAD
            entity.HasKey(e => e.PondId).HasName("PK__Pond__D18BF8546160F1E2");
=======
            entity.HasKey(e => e.PondId).HasName("PK__Pond__D18BF8541DC4C437");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.ToTable("Pond");

            entity.Property(e => e.PondId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PondID");
            entity.Property(e => e.Depth).HasColumnName("depth");
            entity.Property(e => e.DrainCount).HasColumnName("drainCount");
            entity.Property(e => e.ImagePond).HasColumnName("imagePond");
            entity.Property(e => e.NamePond).HasMaxLength(10);
            entity.Property(e => e.PumpCapacity).HasColumnName("pumpCapacity");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.User).WithMany(p => p.Ponds)
                .HasForeignKey(d => d.UserId)
<<<<<<< HEAD
                .HasConstraintName("FK__Pond__UserId__45F365D3");
=======
                .HasConstraintName("FK__Pond__UserId__403A8C7D");
>>>>>>> Nhanh6(3)-BLOGANDNEWS
        });

        modelBuilder.Entity<Product>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.ProductId).HasName("PK___Product__2D10D14A09811653");
=======
            entity.HasKey(e => e.ProductId).HasName("PK___Product__2D10D14ADEC1BE4D");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.ToTable("_Product");

            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(newid())")
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

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
<<<<<<< HEAD
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK___Product__UserId__403A8C7D");
=======
                .HasConstraintName("FK___Product__UserId__534D60F1");
>>>>>>> Nhanh6(3)-BLOGANDNEWS
        });

        modelBuilder.Entity<SaltCalculation>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.SaltCalculationId).HasName("PK__SaltCalc__69E08378609055EE");
=======
            entity.HasKey(e => e.SaltCalculationId).HasName("PK__SaltCalc__69E0837854985CF8");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.ToTable("SaltCalculation");

            entity.Property(e => e.SaltCalculationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("salt_CalculationID");
            entity.Property(e => e.CalculationTime)
                .HasColumnType("datetime")
                .HasColumnName("calculationTime");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.RequiredSaltAmount).HasColumnName("requiredSaltAmount");

            entity.HasOne(d => d.Pond).WithMany(p => p.SaltCalculations)
                .HasForeignKey(d => d.PondId)
<<<<<<< HEAD
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaltCalcu__PondI__3C69FB99");
=======
                .HasConstraintName("FK__SaltCalcu__PondI__4F7CD00D");
>>>>>>> Nhanh6(3)-BLOGANDNEWS
        });

        modelBuilder.Entity<User>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.UserId).HasName("PK___User__1788CC4C7308F1DA");
=======
            entity.HasKey(e => e.UserId).HasName("PK___User__1788CC4CAEE76E51");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.ToTable("_User");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birthDate");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("_Role");

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
<<<<<<< HEAD
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK___User__AccountId__29572725");
=======
                .HasConstraintName("FK___User__AccountId__3C69FB99");
>>>>>>> Nhanh6(3)-BLOGANDNEWS
        });

        modelBuilder.Entity<WaterParameter>(entity =>
        {
<<<<<<< HEAD
            entity.HasKey(e => e.WaterParameterId).HasName("PK__WaterPar__5D1C0C722CB4059A");
=======
            entity.HasKey(e => e.WaterParameterId).HasName("PK__WaterPar__5D1C0C7254F292AE");
>>>>>>> Nhanh6(3)-BLOGANDNEWS

            entity.ToTable("WaterParameter");

            entity.Property(e => e.WaterParameterId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("WaterParameterID");
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
<<<<<<< HEAD
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WaterPara__PondI__38996AB5");
=======
                .HasConstraintName("FK__WaterPara__PondI__4BAC3F29");
>>>>>>> Nhanh6(3)-BLOGANDNEWS
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
