using System;
using Microsoft.IdentityModel.Tokens;

namespace AuthDemo.Identity.Jwt.Extensions
{
    public static class TokenValidationParametersExtensions
    {
        internal static TokenValidationParameters ToTokenValidationParams(
            this JwtOptions tokenOptions) =>
            new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = false,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuer = false,
                ValidIssuer = tokenOptions.Issuer,
                IssuerSigningKey = tokenOptions.SigningKey,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                ValidateLifetime = true
            };
    }
}
