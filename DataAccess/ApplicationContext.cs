using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rds_test.Models;

namespace rds_test.Data;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<ApplicationUser> applicationUsers { get; set; }
    public virtual DbSet<Suggestion> suggestion { get; set; }
    public virtual DbSet<Log> log { get; set; }

    public virtual DbSet<Dept> dept { get; set; }

    public virtual DbSet<Participants> participants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<ApplicationUser>()
        // .Ignore(c => c.AccessFailedCount)
        // .Ignore(c=> c.LockoutEnabled)
        // .Ignore(c=>c.PhoneNumberConfirmed)
        // .Ignore(c=>c.TwoFactorEnabled)
        // .Ignore(c=>c.EmailConfirmed);

        modelBuilder.Entity<Suggestion>()
        .HasKey(c => c.case_num);

        modelBuilder.Entity<ApplicationUser>()
        .HasKey(c => c.Id);

        modelBuilder.Entity<Dept>()
        .HasKey(c => c.team);

        modelBuilder.Entity<Participants>()
        .HasOne(e => e.applicationUsers)
        .WithMany(e => e.participants)
        .HasForeignKey(e => e.Id);

        modelBuilder.Entity<Participants>()
        .HasOne(e => e.suggestion)
        .WithMany(e => e.participants)
        .HasForeignKey(e => e.case_num);

        modelBuilder.Entity<Participants>()
        .HasKey(t => new { t.case_num, t.Id });

        modelBuilder.Entity<ApplicationUser>()
        .HasOne(e => e.dept)
        .WithMany(e => e.applicationUsers)
        .HasForeignKey(e => e.team);

        modelBuilder.Entity<Suggestion>()
        .HasOne(e => e.applicationUsers)
        .WithMany(e => e.suggestions)
        .HasForeignKey(e => e.Id);

        modelBuilder.Entity<Log>()
        .HasOne(e => e.suggestion)
        .WithMany(e => e.log)
        .HasForeignKey(e => e.case_num);

        modelBuilder.Entity<Log>()
        .HasOne(e => e.applicationUsers)
        .WithMany(e => e.log)
        .HasForeignKey(e => e.Id);

         modelBuilder.Entity<Log>()
        .Property(e => e.timestamp)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<Log>()
        .HasKey(e => new {e.case_num, e.Id, e.timestamp});
    


        modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfigurations());
    }
}
public class ApplicationUserEntityConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
    }
}

