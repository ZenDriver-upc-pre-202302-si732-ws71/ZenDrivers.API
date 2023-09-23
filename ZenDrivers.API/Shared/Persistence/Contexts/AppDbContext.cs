using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Enums;
using ZenDrivers.API.Shared.Extensions;

namespace ZenDrivers.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Recruiter> Recruiters { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<License> Licenses { get; set; }
    public DbSet<DriverExperience> DriverExperiences { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    
    public DbSet<Message> Messages { get; set; }
    public DbSet<LicenseCategory> LicenseCategories { get; set; }
    
    public AppDbContext(DbContextOptions options) : base (options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    base.OnModelCreating(builder);


        builder.Entity<Account>(e =>
        {
            e.ToTable("Accounts");
            e.HasKey(u => u.Id);
            e.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            e.Property(a => a.Username).IsRequired();
            e.Property(a => a.Firstname).IsRequired();
            e.Property(a => a.Lastname).IsRequired();
            e.Property(a => a.Phone).IsRequired().HasMaxLength(10);
            e.Property(a => a.Role)
                .IsRequired()
                .HasMaxLength(10)
                .HasConversion(v => v.ToString(),
                    v => (UserType) Enum.Parse(typeof(UserType), v));
            e.Navigation(a => a.Driver).AutoInclude();
            e.Navigation(a => a.Recruiter).AutoInclude();
        });

        builder.Entity<Recruiter>(e =>
        {
            e.ToTable("Recruiters");
            e.HasKey(r => r.Id);
            e.Property(r => r.Description);
            e.Property(r => r.Email).IsRequired();
            e.Navigation(r => r.Account).AutoInclude();
        });
        
        builder.Entity<Driver>(e =>
        {
            e.ToTable("Drivers");
            e.HasKey(d => d.Id);
            e.Property(d => d.Address);
            e.Property(d => d.Birth).HasDefaultValue(DateTime.Now);
            e.Navigation(d => d.Account).AutoInclude();
        });
        
        builder.Entity<Post>(e =>
        {
            e.ToTable("Posts");
            e.HasKey(p => p.Id);
            e.Property(p => p.Title).IsRequired();
            e.Property(p => p.Description).IsRequired();
            e.Property(p => p.Date).HasDefaultValue(DateTime.Now);
            e.Property(p => p.Image);
            e.Navigation(p => p.Recruiter).AutoInclude();
        });

        builder.Entity<Company>(e =>
        {
            e.ToTable("Companies");
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).IsRequired();
            e.Property(c => c.Ruc).IsRequired();
            e.Property(c => c.Owner).IsRequired();
            e.Property(c => c.Address).IsRequired();
        });

        builder.Entity<LicenseCategory>(e =>
        {
            e.ToTable("LicenseCategories");
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).IsRequired();
        });

        builder.Entity<License>(e =>
        {
            e.ToTable("Licenses");
            e.HasKey(l => l.Id);
            e.Property(l => l.Start).IsRequired();
            e.Property(l => l.End).IsRequired();
            e.Navigation(l => l.Category).AutoInclude();
        });

        builder.Entity<DriverExperience>(e =>
        {
            e.ToTable("DriverExperiences");
            e.HasKey(d => d.Id);
            e.Property(d => d.Description).IsRequired();
            e.Property(d => d.StartDate).IsRequired();
            e.Property(d => d.EndDate).IsRequired();
        });

        builder.Entity<Message>(e =>
        {
            e.ToTable("Messages");
            e.HasKey(m => m.Id);
            e.Property(m => m.Content).IsRequired();
            e.Property(m => m.Date).HasDefaultValue(DateTime.Now);
        });
        
        // Relations
        builder.Entity<LicenseCategory>()
            .HasMany<License>()
            .WithOne(l => l.Category)
            .HasForeignKey(l => l.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Driver>()
            .HasMany<License>()
            .WithMany()
            .UsingEntity("LicenseDrivers");
        
        builder.Entity<Recruiter>()
            .HasMany<Post>()
            .WithOne(p=> p.Recruiter)
            .HasForeignKey(p => p.RecruiterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Recruiter>()
            .HasOne(r => r.Account)
            .WithOne(a => a.Recruiter)
            .HasForeignKey<Recruiter>(r => r.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Driver>()
            .HasOne(d => d.Account)
            .WithOne(a => a.Driver)
            .HasForeignKey<Driver>(d => d.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
        

        builder.Entity<Recruiter>()
            .HasOne<Company>()
            .WithMany()
            .HasForeignKey(u => u.CompanyId);

        builder.Entity<Driver>()
            .HasMany<DriverExperience>()
            .WithOne(e => e.Driver)
            .HasForeignKey(e => e.DriverId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Account>()
            .HasMany<Message>()
            .WithOne(m => m.Receiver)
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Account>()
            .HasMany<Message>()
            .WithOne(m => m.Sender)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}
