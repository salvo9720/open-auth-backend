using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.NTT;

namespace open_auth_backend.Database.AppDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Domain> Domains => Set<Domain>();

    public DbSet<UserDomain> UserDomains => Set<UserDomain>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<Device> Devices => Set<Device>();

    public DbSet<Session> Sessions => Set<Session>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<User>()
            .HasIndex(x => x.Username)
            .IsUnique();

        // Domain
        modelBuilder.Entity<Domain>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Domain>()
            .HasIndex(x => x.Name)
            .IsUnique();

        // Permission
        modelBuilder.Entity<Permission>()
            .HasKey(x => x.Id);

        // UserDomain
        modelBuilder.Entity<UserDomain>()
            .HasKey(x => new
            {
                x.UserId,
                x.DomainId
            });

        modelBuilder.Entity<UserDomain>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserDomains)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<UserDomain>()
            .HasOne(x => x.Domain)
            .WithMany(x => x.UserDomains)
            .HasForeignKey(x => x.DomainId);

        modelBuilder.Entity<UserDomain>()
            .HasOne(x => x.Permission)
            .WithMany(x => x.UserDomains)
            .HasForeignKey(x => x.PermissionId);

        // Device
        modelBuilder.Entity<Device>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Device>()
            .HasOne(x => x.User)
            .WithMany(x => x.Devices)
            .HasForeignKey(x => x.UserId);

        // Session
        modelBuilder.Entity<Session>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Session>()
            .HasOne(x => x.User)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<Session>()
            .HasOne(x => x.Device)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.DeviceId);

        modelBuilder.Entity<Session>()
            .HasIndex(x => x.TokenHash)
            .IsUnique();
    }
}