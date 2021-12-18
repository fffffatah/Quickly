using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class Otp
    {
        public long Id { get; set; }
        public string? Otp1 { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
