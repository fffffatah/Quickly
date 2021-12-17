using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class Project
    {
        public Project()
        {
            FkProjectsUsers = new HashSet<FkProjectsUser>();
        }

        public long Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDetails { get; set; }
        public string? ProjectImageUrl { get; set; }

        public virtual ICollection<FkProjectsUser> FkProjectsUsers { get; set; }
    }
}
