﻿using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using rds_test.Models;


namespace rds_test.Data
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Emp> emp { get; set; }

        public virtual DbSet<Suggestion> suggestion { get; set; }
        public virtual DbSet<Log> log { get; set; }

        public virtual DbSet<Dept> dept { get; set; }

        public virtual DbSet<Participants> participants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suggestion>()
            .HasKey(c => c.case_num);

            modelBuilder.Entity<Emp>()
            .HasKey(c => c.emp_num);

            modelBuilder.Entity<Dept>()
            .HasKey(c => c.team);

            modelBuilder.Entity<Participants>()
            .HasKey(t => new { t.case_num, t.emp_num });

            modelBuilder.Entity<Participants>()
            .HasOne(e => e.emp)
            .WithMany(e => e.participants)
            .HasForeignKey(e => e.emp_num);

            modelBuilder.Entity<Participants>()
            .HasOne(e => e.suggestion)
            .WithMany(e => e.participants)
            .HasForeignKey(e => e.case_num);

            modelBuilder.Entity<Emp>()
            .HasOne(e => e.dept)
            .WithMany(e => e.emp)
            .HasForeignKey(e => e.team);


            modelBuilder.Entity<Emp>()
            .Property(m => m.emp_num)
            .ValueGeneratedNever();

        }
    }


}
