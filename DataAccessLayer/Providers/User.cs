using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            FkProjectsUsers = new HashSet<FkProjectsUser>();
            Otps = new HashSet<Otp>();
            Tasks = new HashSet<Task>();
        }

        public long Id { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Pass { get; set; }
        public string? UserType { get; set; }
        public bool? IsVerified { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FkProjectsUser> FkProjectsUsers { get; set; }
        public virtual ICollection<Otp> Otps { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
