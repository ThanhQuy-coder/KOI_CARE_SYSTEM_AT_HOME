﻿// <auto-generated />
using System;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KoiCareSystemAtHome.Repositories.Migrations
{
    [DbContext(typeof(KoiCareSystemAtHomeContext))]
    [Migration("20241115145659_minhquan")]
    partial class minhquan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("PassWordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWorkHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("passWorkHash");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AccountId")
                        .HasName("PK__Account__349DA586BFFA8EDE");

                    b.HasIndex(new[] { "Username" }, "UQ__Account__536C85E4E411DF1D")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Account__AB6E61647D497C94")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.FeedingSchedule", b =>
                {
                    b.Property<Guid>("FeedingScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("feeding_ScheduleID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("FeedingTime")
                        .HasColumnType("datetime")
                        .HasColumnName("feedingTime");

                    b.Property<Guid?>("FishId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("fishID");

                    b.Property<string>("FoodType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("foodType");

                    b.Property<double>("RequiredFoodAmount")
                        .HasColumnType("float")
                        .HasColumnName("requiredFoodAmount");

                    b.HasKey("FeedingScheduleId")
                        .HasName("PK__FeedingS__1B08C84542D06A71");

                    b.HasIndex("FishId");

                    b.ToTable("FeedingSchedule", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.KoiFish", b =>
                {
                    b.Property<Guid>("FishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("fishID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("AgeFish")
                        .HasColumnType("int")
                        .HasColumnName("ageFish");

                    b.Property<string>("BodyShape")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("bodyShape");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("breed");

                    b.Property<int>("FishLocation")
                        .HasColumnType("int")
                        .HasColumnName("fishLocation");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("ImageFish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("imageFish");

                    b.Property<string>("NameFish")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("nameFish");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("origin");

                    b.Property<Guid?>("PondId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PondID");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<double>("Size")
                        .HasColumnType("float")
                        .HasColumnName("size");

                    b.Property<double>("WeightFish")
                        .HasColumnType("float")
                        .HasColumnName("weightFish");

                    b.HasKey("FishId")
                        .HasName("PK__KoiFish__5222DA391BAAB9AE");

                    b.HasIndex("PondId");

                    b.ToTable("KoiFish", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.News", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("postID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("author");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("content");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime")
                        .HasColumnName("publishDate");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("PostId")
                        .HasName("PK__News__DD0C73BA884B0BE7");

                    b.HasIndex(new[] { "Author" }, "UQ__News__C2E6DB671928440D")
                        .IsUnique();

                    b.ToTable("News");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.Pond", b =>
                {
                    b.Property<Guid>("PondId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PondID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<double?>("Depth")
                        .HasColumnType("float")
                        .HasColumnName("depth");

                    b.Property<int?>("DrainCount")
                        .HasColumnType("int")
                        .HasColumnName("drainCount");

                    b.Property<string>("ImagePond")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("imagePond");

                    b.Property<string>("NamePond")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<double?>("PumpCapacity")
                        .HasColumnType("float")
                        .HasColumnName("pumpCapacity");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Volume")
                        .HasColumnType("float")
                        .HasColumnName("volume");

                    b.HasKey("PondId")
                        .HasName("PK__Pond__D18BF8541C4B2D40");

                    b.HasIndex("UserId");

                    b.ToTable("Pond", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("DatePlace")
                        .HasColumnType("datetime")
                        .HasColumnName("datePlace");

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("desciption");

                    b.Property<string>("ImageProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("imageProduct");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("productName");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("productType");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId")
                        .HasName("PK___Product__2D10D14AF3D98433");

                    b.HasIndex("UserId");

                    b.ToTable("_Product", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.SaltCalculation", b =>
                {
                    b.Property<Guid>("SaltCalculationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("salt_CalculationID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("CalculationTime")
                        .HasColumnType("datetime")
                        .HasColumnName("calculationTime");

                    b.Property<Guid?>("PondId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PondID");

                    b.Property<double?>("RequiredSaltAmount")
                        .HasColumnType("float")
                        .HasColumnName("requiredSaltAmount");

                    b.HasKey("SaltCalculationId")
                        .HasName("PK__SaltCalc__69E0837868F56082");

                    b.HasIndex("PondId");

                    b.ToTable("SaltCalculation", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime")
                        .HasColumnName("birthDate");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("fullName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("_Role");

                    b.HasKey("UserId")
                        .HasName("PK___User__1788CC4C688C32AF");

                    b.HasIndex("AccountId");

                    b.ToTable("_User", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.WaterParameter", b =>
                {
                    b.Property<Guid>("WaterParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("WaterParameterID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("MeasurementTime")
                        .HasColumnType("datetime")
                        .HasColumnName("measurementTime");

                    b.Property<double>("Nitrate")
                        .HasColumnType("float")
                        .HasColumnName("nitrate");

                    b.Property<double>("Nitrie")
                        .HasColumnType("float")
                        .HasColumnName("nitrie");

                    b.Property<double>("Oxygen")
                        .HasColumnType("float")
                        .HasColumnName("oxygen");

                    b.Property<double>("PH")
                        .HasColumnType("float")
                        .HasColumnName("pH");

                    b.Property<double>("Phospate")
                        .HasColumnType("float")
                        .HasColumnName("phospate");

                    b.Property<Guid?>("PondId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PondID");

                    b.Property<double>("SaltLevel")
                        .HasColumnType("float")
                        .HasColumnName("saltLevel");

                    b.Property<double>("Temperature")
                        .HasColumnType("float")
                        .HasColumnName("temperature");

                    b.HasKey("WaterParameterId")
                        .HasName("PK__WaterPar__5D1C0C728A04E1A9");

                    b.HasIndex("PondId");

                    b.ToTable("WaterParameter", (string)null);
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.FeedingSchedule", b =>
                {
                    b.HasOne("KoiCareSystemAtHome.Repositories.Entities.KoiFish", "Fish")
                        .WithMany("FeedingSchedules")
                        .HasForeignKey("FishId")
                        .HasConstraintName("FK__FeedingSc__fishI__47DBAE45");

                    b.Navigation("Fish");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.KoiFish", b =>
                {
                    b.HasOne("KoiCareSystemAtHome.Repositories.Entities.Pond", "Pond")
                        .WithMany("KoiFishes")
                        .HasForeignKey("PondId")
                        .HasConstraintName("FK__KoiFish__PondID__440B1D61");

                    b.Navigation("Pond");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.Pond", b =>
                {
                    b.HasOne("KoiCareSystemAtHome.Repositories.Entities.User", "User")
                        .WithMany("Ponds")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Pond__UserId__403A8C7D");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.Product", b =>
                {
                    b.HasOne("KoiCareSystemAtHome.Repositories.Entities.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK___Product__UserId__534D60F1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.SaltCalculation", b =>
                {
                    b.HasOne("KoiCareSystemAtHome.Repositories.Entities.Pond", "Pond")
                        .WithMany("SaltCalculations")
                        .HasForeignKey("PondId")
                        .HasConstraintName("FK__SaltCalcu__PondI__4F7CD00D");

                    b.Navigation("Pond");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.User", b =>
                {
                    b.HasOne("KoiCareSystemAtHome.Repositories.Entities.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK___User__AccountId__3C69FB99");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.WaterParameter", b =>
                {
                    b.HasOne("KoiCareSystemAtHome.Repositories.Entities.Pond", "Pond")
                        .WithMany("WaterParameters")
                        .HasForeignKey("PondId")
                        .HasConstraintName("FK__WaterPara__PondI__4BAC3F29");

                    b.Navigation("Pond");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.Account", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.KoiFish", b =>
                {
                    b.Navigation("FeedingSchedules");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.Pond", b =>
                {
                    b.Navigation("KoiFishes");

                    b.Navigation("SaltCalculations");

                    b.Navigation("WaterParameters");
                });

            modelBuilder.Entity("KoiCareSystemAtHome.Repositories.Entities.User", b =>
                {
                    b.Navigation("Ponds");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
