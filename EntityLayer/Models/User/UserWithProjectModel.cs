using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.User
{
    public class UserWithProjectModel
    {
        public long Id { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Pass { get; set; }
        public string? UserType { get; set; }
        public bool IsVerified { get; set; }
        public List<ProjectModel>? Projects { get; set; }

    }
}
