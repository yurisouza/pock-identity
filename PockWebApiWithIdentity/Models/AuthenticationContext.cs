using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace PockWebApiWithIdentity.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("User");
                entity.Property(m => m.Email).HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
                entity.Property(m => m.UserName).HasMaxLength(127);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Role");
                entity.Property(m => m.Name).HasMaxLength(127);
                entity.Property(m => m.NormalizedName).HasMaxLength(127);
            });

            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRole");
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.RoleId).HasMaxLength(127);
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogin");
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.ProviderKey).HasMaxLength(127);
            });

            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserToken");
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.Name).HasMaxLength(127);
            });
        }
    }
}