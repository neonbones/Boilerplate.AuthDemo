using AuthDemo.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo.Domain.Entities.Identity
{
    public class Role : IdentityRole<long>, IEntity
    {
        public enum Types
        {
            Administrator,
            User
        }

        protected Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {
            NormalizedName = roleName.ToUpperInvariant();
        }
    }
}
