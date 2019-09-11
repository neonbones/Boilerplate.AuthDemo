using System;

namespace AuthDemo.Identity.Jwt.Models
{
    public sealed class JwtTokenResult
    {
        public string AccessToken { get; internal set; }

        public TimeSpan Expires { get; set; }
    }
}
