using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Providers;

namespace DataAccessLayer.IProviders
{
    public interface IFKProjectsUserProvider : IEntityProvider<FkProjectsUser, long>
    {
        public FkProjectsUser GetOne(long userId, long projectId);
    }
}
