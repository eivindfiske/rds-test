﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rds_test.Data;

#nullable disable

namespace rds_test.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221110162350_TestDate")]
    partial class TestDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("rds_test.Models.ApplicationUser", b =>
                {
                    b.Property<string>("emp_num")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("team")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("emp_num");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("team");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("rds_test.Models.Dept", b =>
                {
                    b.Property<string>("team")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("dept")
                        .HasColumnType("longtext");

                    b.HasKey("team");

                    b.ToTable("dept");
                });

            modelBuilder.Entity("rds_test.Models.Log", b =>
                {
                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("case_num")
                        .HasColumnType("int");

                    b.Property<string>("edit_msg")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("emp_num")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("timestamp");

                    b.ToTable("log");
                });

            modelBuilder.Entity("rds_test.Models.Participants", b =>
                {
                    b.Property<int>("case_num")
                        .HasColumnType("int");

                    b.Property<string>("emp_num")
                        .HasColumnType("varchar(255)");

                    b.HasKey("case_num", "emp_num");

                    b.HasIndex("emp_num");

                    b.ToTable("participants");
                });

            modelBuilder.Entity("rds_test.Models.Suggestion", b =>
                {
                    b.Property<int>("case_num")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly?>("deadline")
                        .HasColumnType("Date");

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("emp_num")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("pdsa_act")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("pdsa_do")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("pdsa_plan")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("pdsa_study")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<byte[]>("pic_after")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("pic_before")
                        .HasColumnType("longblob");

                    b.Property<string>("resdept")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("responsible")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("status")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("timeframe")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(0)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("case_num");

                    b.HasIndex("emp_num");

                    b.ToTable("suggestion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("rds_test.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("rds_test.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rds_test.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("rds_test.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("rds_test.Models.ApplicationUser", b =>
                {
                    b.HasOne("rds_test.Models.Dept", "dept")
                        .WithMany("applicationUsers")
                        .HasForeignKey("team")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dept");
                });

            modelBuilder.Entity("rds_test.Models.Participants", b =>
                {
                    b.HasOne("rds_test.Models.Suggestion", "suggestion")
                        .WithMany("participants")
                        .HasForeignKey("case_num")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rds_test.Models.ApplicationUser", "applicationUsers")
                        .WithMany("participants")
                        .HasForeignKey("emp_num")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("applicationUsers");

                    b.Navigation("suggestion");
                });

            modelBuilder.Entity("rds_test.Models.Suggestion", b =>
                {
                    b.HasOne("rds_test.Models.ApplicationUser", "applicationUsers")
                        .WithMany("suggestions")
                        .HasForeignKey("emp_num")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("applicationUsers");
                });

            modelBuilder.Entity("rds_test.Models.ApplicationUser", b =>
                {
                    b.Navigation("participants");

                    b.Navigation("suggestions");
                });

            modelBuilder.Entity("rds_test.Models.Dept", b =>
                {
                    b.Navigation("applicationUsers");
                });

            modelBuilder.Entity("rds_test.Models.Suggestion", b =>
                {
                    b.Navigation("participants");
                });
#pragma warning restore 612, 618
        }
    }
}
