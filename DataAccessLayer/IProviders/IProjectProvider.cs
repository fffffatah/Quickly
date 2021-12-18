using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Providers;

namespace DataAccessLayer.IProviders
{
    public interface IProjectProvider : IEntityProvider<Project, long>
    {
        public List<Project> GetForUser(long userId);
        public List<Project> GetForOwner(long userId);
        public List<Project> GetForMember(long userId);
        public long AddGetId(Project e);
    }
}
