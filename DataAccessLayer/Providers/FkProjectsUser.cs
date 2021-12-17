using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class FkProjectsUser
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsProjectEditor { get; set; }
        public bool? IsTaskEditor { get; set; }
        public bool? IsInvitor { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
