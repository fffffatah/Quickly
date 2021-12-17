using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class FKProjectsUsersModel
    {
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long? UserId { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsProjectEditor { get; set; }
        public bool? IsTaskEditor { get; set; }
        public bool? IsInvitor { get; set; }
    }
}
