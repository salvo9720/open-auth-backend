using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.NTT;

namespace open_auth_backend.Database.AppDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserNTT> Users => Set<UserNTT>();

    public DbSet<DomainNTT> Domains => Set<DomainNTT>();

    public DbSet<UserDomainNTT> UserDomains => Set<UserDomainNTT>();

    public DbSet<PermissionNTT> Permissions => Set<PermissionNTT>();

    public DbSet<DeviceNTT> Devices => Set<DeviceNTT>();

    public DbSet<SessionNTT> Sessions => Set<SessionNTT>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<UserNTT>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<UserNTT>()
            .HasIndex(x => x.Username)
            .IsUnique();

        // Domain
        modelBuilder.Entity<DomainNTT>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<DomainNTT>()
            .HasIndex(x => x.Name)
            .IsUnique();

        // Permission
        modelBuilder.Entity<PermissionNTT>()
            .HasKey(x => x.Id);

        // UserDomain
        modelBuilder.Entity<UserDomainNTT>()
            .HasKey(x => new
            {
                x.UserId,
                x.DomainId
            });

        modelBuilder.Entity<UserDomainNTT>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserDomains)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<UserDomainNTT>()
            .HasOne(x => x.Domain)
            .WithMany(x => x.UserDomains)
            .HasForeignKey(x => x.DomainId);

        modelBuilder.Entity<UserDomainNTT>()
            .HasOne(x => x.Permission)
            .WithMany(x => x.UserDomains)
            .HasForeignKey(x => x.PermissionId);

        // Device
        modelBuilder.Entity<DeviceNTT>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<DeviceNTT>()
            .HasOne(x => x.User)
            .WithMany(x => x.Devices)
            .HasForeignKey(x => x.UserId);

        // Session
        modelBuilder.Entity<SessionNTT>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<SessionNTT>()
            .HasOne(x => x.User)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<SessionNTT>()
            .HasOne(x => x.Device)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.DeviceId);

        modelBuilder.Entity<SessionNTT>()
            .HasIndex(x => x.TokenHash)
            .IsUnique();
    }
}