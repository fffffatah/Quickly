using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Providers;

namespace DataAccessLayer.IProviders
{
    public interface ITaskProvider : IEntityProvider<Providers.Task, Guid>
    {
    }
}
