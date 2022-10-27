﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rds_test.Data;

#nullable disable

namespace rds_test.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("rds_test.Models.Dept", b =>
                {
                    b.Property<string>("team")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("dept")
                        .HasColumnType("longtext");

                    b.HasKey("team");

                    b.ToTable("dept");
                });

            modelBuilder.Entity("rds_test.Models.Emp", b =>
                {
                    b.Property<int>("emp_num")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<bool>("admin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("password")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("team")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("emp_num");

                    b.HasIndex("team");

                    b.ToTable("emp");
                });

            modelBuilder.Entity("rds_test.Models.Log", b =>
                {
                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("case_num")
                        .HasColumnType("int");

                    b.Property<string>("edit_msg")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("emp_num")
                        .HasColumnType("int");

                    b.HasKey("timestamp");

                    b.ToTable("log");
                });

            modelBuilder.Entity("rds_test.Models.Participants", b =>
                {
                    b.Property<int>("case_num")
                        .HasColumnType("int");

                    b.Property<int>("emp_num")
                        .HasColumnType("int");

                    b.HasKey("case_num", "emp_num");

                    b.HasIndex("emp_num");

                    b.ToTable("participants");
                });

            modelBuilder.Entity("rds_test.Models.Suggestion", b =>
                {
                    b.Property<int>("case_num")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<DateOnly>("deadline")
                        .HasColumnType("date");

                    b.Property<string>("description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("pdsa_act")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("pdsa_do")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("pdsa_plan")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("pdsa_study")
                        .HasColumnType("varchar(500)");

                    b.Property<byte[]>("pic_after")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("pic_before")
                        .HasColumnType("longblob");

                    b.Property<string>("resdept")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("responsible")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("status")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("timeframe")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("title")
                        .HasColumnType("varchar(50)");

                    b.HasKey("case_num");

                    b.ToTable("suggestion");
                });

            modelBuilder.Entity("rds_test.Models.Emp", b =>
                {
                    b.HasOne("rds_test.Models.Dept", "dept")
                        .WithMany("emp")
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

                    b.HasOne("rds_test.Models.Emp", "emp")
                        .WithMany("participants")
                        .HasForeignKey("emp_num")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("emp");

                    b.Navigation("suggestion");
                });

            modelBuilder.Entity("rds_test.Models.Dept", b =>
                {
                    b.Navigation("emp");
                });

            modelBuilder.Entity("rds_test.Models.Emp", b =>
                {
                    b.Navigation("participants");
                });

            modelBuilder.Entity("rds_test.Models.Suggestion", b =>
                {
                    b.Navigation("participants");
                });
#pragma warning restore 612, 618
        }
    }
}
