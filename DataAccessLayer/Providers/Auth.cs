using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class Auth
    {
        public long Id { get; set; }
        public string? RefreshToken { get; set; }
        public DateOnly? ExpiresAt { get; set; }
        public string? IpAddress { get; set; }
    }
}
