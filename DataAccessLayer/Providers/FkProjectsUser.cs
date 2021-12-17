using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class FkProjectsUser
    {
        public Guid Id { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsProjectEditor { get; set; }
        public bool? IsTaskEditor { get; set; }
        public bool? IsInvitor { get; set; }

        public virtual Project? Project { get; set; }
        public virtual User? User { get; set; }
    }
}
