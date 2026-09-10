using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience {  get; set; } = string.Empty;
        public string SecretKey {  get; set; } = string.Empty;
    }
}
