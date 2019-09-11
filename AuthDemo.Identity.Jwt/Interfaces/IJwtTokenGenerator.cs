using System.Collections.Generic;
using AuthDemo.Domain.Entities.Identity;
using AuthDemo.Identity.Jwt.Models;

namespace AuthDemo.Identity.Jwt.Interfaces
{
    public interface IJwtTokenGenerator
    {
        JwtTokenResult Generate(User user, IList<string> roles);
    }
}
