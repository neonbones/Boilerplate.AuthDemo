using AuthDemo.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Infrastructure.Data.Contexts
{
    public partial class ApplicationContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<IdentityUserRole<long>> UserRoles { get; set; }

        public DbSet<IdentityUserClaim<long>> IdentityUserClaims { get; set; }

        public DbSet<IdentityRoleClaim<long>> IdentityRoleClaims { get; set; }
    }
}
