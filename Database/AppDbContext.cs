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

    public DbSet<PasswordResetTokenNTT> PasswordResetTokens => Set<PasswordResetTokenNTT>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<UserNTT>()
            .HasKey(x => x.id);

        modelBuilder.Entity<UserNTT>()
            .HasIndex(x => x.username)
            .IsUnique();

        modelBuilder.Entity<UserNTT>()
            .HasIndex(x => x.email)
            .IsUnique();

        modelBuilder.Entity<UserNTT>()
            .HasIndex(x => x.email)
            .IsUnique();

        // Domain
        modelBuilder.Entity<DomainNTT>()
            .HasKey(x => x.id);

        modelBuilder.Entity<DomainNTT>()
            .HasIndex(x => x.name)
            .IsUnique();

        // Permission
        modelBuilder.Entity<PermissionNTT>()
            .HasKey(x => x.id);

        // UserDomain
        modelBuilder.Entity<UserDomainNTT>()
            .HasKey(x => new
            {
                x.userId,
                x.domainId
            });

        modelBuilder.Entity<UserDomainNTT>()
            .HasOne(x => x.user)
            .WithMany(x => x.userDomains)
            .HasForeignKey(x => x.userId);

        modelBuilder.Entity<UserDomainNTT>()
            .HasOne(x => x.domain)
            .WithMany(x => x.userDomains)
            .HasForeignKey(x => x.domainId);

        modelBuilder.Entity<UserDomainNTT>()
            .HasOne(x => x.permission)
            .WithMany(x => x.userDomains)
            .HasForeignKey(x => x.permissionId);

        // Device
        modelBuilder.Entity<DeviceNTT>()
            .HasKey(x => x.id);

        modelBuilder.Entity<DeviceNTT>()
            .HasMany(x => x.user)
            .WithMany(x => x.devices)
            .UsingEntity(x => x.ToTable("user_devices"));

        // Session
        modelBuilder.Entity<SessionNTT>()
            .HasKey(x => x.id);

        modelBuilder.Entity<SessionNTT>()
            .HasOne(x => x.user)
            .WithMany(x => x.sessions)
            .HasForeignKey(x => x.userId);

        modelBuilder.Entity<SessionNTT>()
            .HasOne(x => x.device)
            .WithMany(x => x.sessions)
            .HasForeignKey(x => x.deviceId);

        modelBuilder.Entity<SessionNTT>()
            .HasIndex(x => x.tokenHash)
            .IsUnique();
    }
}