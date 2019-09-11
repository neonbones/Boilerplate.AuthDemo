using AuthDemo.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo.Domain.Entities.Identity
{
    public class User : IdentityUser<long>, IEntity
    {
    }
}
