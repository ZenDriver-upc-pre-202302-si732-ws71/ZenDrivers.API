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
    public DbSet<Like> PostLikes { get; set; }
    public DbSet<LicenseCategory> LicenseCategories { get; set; }
    public DbSet<Comment> PostsComments { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    
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
            e.Property(a => a.ImageUrl);
            e.Navigation(a => a.Driver).AutoInclude();
            e.Navigation(a => a.Recruiter).AutoInclude();
        });

        builder.Entity<Recruiter>(e =>
        {
            e.ToTable("Recruiters");
            e.HasKey(r => r.Id);
            e.Property(r => r.Description);
            e.Property(r => r.Email).IsRequired();
            e.Property(r => r.Verified).HasDefaultValue(false);
            e.Navigation(r => r.Account).AutoInclude();
            e.Navigation(r => r.Company).AutoInclude();
        });
        
        builder.Entity<Driver>(e =>
        {
            e.ToTable("Drivers");
            e.HasKey(d => d.Id);
            e.Property(d => d.Address);
            e.Property(d => d.Birth).HasDefaultValue(DateTime.Now);
            e.Navigation(d => d.Account).AutoInclude();
            e.Navigation(d => d.Experiences).AutoInclude();
            e.Navigation(d => d.Licenses).AutoInclude();
        });
        
        builder.Entity<Post>(e =>
        {
            e.ToTable("Posts");
            e.HasKey(p => p.Id);
            e.Property(p => p.Title).IsRequired();
            e.Property(p => p.Description).IsRequired();
            e.Property(p => p.Date);
            e.Property(p => p.Image);
            e.Navigation(p => p.Recruiter).AutoInclude();
            e.Navigation(p => p.Likes).AutoInclude();
            e.Navigation(p => p.Comments).AutoInclude();
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
            e.Navigation(l => l.Driver).AutoInclude();
        });

        builder.Entity<DriverExperience>(e =>
        {
            e.ToTable("DriverExperiences");
            e.HasKey(d => d.Id);
            e.Property(d => d.Description).IsRequired();
            e.Property(d => d.StartDate).IsRequired();
            e.Property(d => d.EndDate).IsRequired();
            e.Navigation(d => d.Driver).AutoInclude();
        });

        builder.Entity<Message>(e =>
        {
            e.ToTable("Messages");
            e.HasKey(m => m.Id);
            e.Property(m => m.Content).IsRequired();
            e.Property(m => m.Date);
            e.Navigation(m => m.Account).AutoInclude();
        });

        builder.Entity<Like>(e =>
        {
            e.ToTable("PostLikes");
            e.HasKey(l => l.Id);
            e.Navigation(l => l.Account).AutoInclude();
            e.Navigation(l => l.Post).AutoInclude();
        });

        builder.Entity<Comment>(e =>
        {
            e.ToTable("PostComments");
            e.HasKey(c => c.Id);
            e.Property(c => c.Content).IsRequired();
            e.Property(c => c.Date);
            e.Navigation(c => c.Post).AutoInclude();
            e.Navigation(c => c.Account).AutoInclude();
        });
        
        builder.Entity<Conversation>(e =>
        {
            e.ToTable("Conversations");
            e.HasKey(c => c.Id);
            e.Navigation(c => c.Receiver).AutoInclude();
            e.Navigation(c => c.Sender).AutoInclude();
            e.Navigation(c => c.Messages).AutoInclude();
        });
        
        // Relations
        builder.Entity<LicenseCategory>()
            .HasMany<License>()
            .WithOne(l => l.Category)
            .HasForeignKey(l => l.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Driver>()
            .HasMany(d=> d.Licenses)
            .WithOne(l => l.Driver)
            .HasForeignKey(l => l.DriverId);
        
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
            .HasOne(r => r.Company)
            .WithMany()
            .HasForeignKey(u => u.CompanyId);

        builder.Entity<Driver>()
            .HasMany(d => d.Experiences)
            .WithOne(e => e.Driver)
            .HasForeignKey(e => e.DriverId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Account>()
            .HasMany<Conversation>()
            .WithOne(m => m.Receiver)
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Account>()
            .HasMany<Message>()
            .WithOne(m => m.Account)
            .HasForeignKey(m => m.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Account>()
            .HasMany<Conversation>()
            .WithOne(m => m.Sender)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Conversation>()
            .HasMany(c => c.Messages)
            .WithOne()
            .HasForeignKey(m => m.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Account>()
            .HasMany<Like>()
            .WithOne(l => l.Account)
            .HasForeignKey(l => l.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Account>()
            .HasMany<Comment>()
            .WithOne(c => c.Account)
            .HasForeignKey(c => c.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Post>()
            .HasMany(p => p.Likes)
            .WithOne(l => l.Post)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}
