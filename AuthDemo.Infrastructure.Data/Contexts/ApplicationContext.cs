using AuthDemo.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Infrastructure.Data.Contexts
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<long>>()
                .HasKey(r => new { r.UserId, r.RoleId });

            builder.Entity<IdentityUserRole<long>>()
                .ToTable("UserRoles");

            builder.Entity<IdentityUserClaim<long>>()
                .ToTable("UserClaims");

            base.OnModelCreating(builder);
        }
    }
}
