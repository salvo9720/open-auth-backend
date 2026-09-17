using Microsoft.EntityFrameworkCore;
using open_auth_backend.Database.NTT;
using System.Reflection.Emit;

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
        this.seedDatabase(modelBuilder);
    }

    protected void seedDatabase(ModelBuilder modelBuilder)
    {
        // user default auth: admin admin
        modelBuilder.Entity<DomainNTT>().HasData(
            new
            {
                id = 1,
                name = "dominioTest"
            }
        );

        modelBuilder.Entity<PermissionNTT>().HasData(
            new
            {
                id = 1,
                level = 0
            }
        );

        modelBuilder.Entity<UserNTT>().HasData(
            new
            {
                id = 3,
                username = "admin",
                email = "admin",
                passwordHash = "$2a$11$KudszP34FzcMNZLggar73eOS.KqfkvqzKjho.F4MsFN0LoG.xuTTi",
                createdAt = new DateTime(
                    2026,
                    9,
                    16,
                    12,
                    55,
                    31,
                    670,
                    DateTimeKind.Utc
                ),
                deletedAt = (DateTime?)null
            }
        );

        modelBuilder.Entity<UserDomainNTT>().HasData(
            new
            {
                id = 3,
                userId = 3,
                domainId = 1,
                permissionId = 1
            }
        );
    }
}