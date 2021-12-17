using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class FKProjectsUsers
    {
        public Guid Id { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsProjectEditor { get; set; }
        public bool? IsTaskEditor { get; set; }
        public bool? IsInvitor { get; set; }
    }
}
