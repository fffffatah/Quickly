using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Providers;
using Task = DataAccessLayer.Providers.Task;

namespace DataAccessLayer.IProviders
{
    public interface ITaskProvider : IEntityProvider<Providers.Task, long>
    {
        public List<Task> GetForProject(long projectId);
        public List<Task> GetForAssignee(long projectId, long assignedTo);
    }
}
