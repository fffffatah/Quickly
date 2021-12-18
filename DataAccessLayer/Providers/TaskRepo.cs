using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class TaskRepo : ITaskProvider
    {
        QuicklyContext _db;
        public TaskRepo(QuicklyContext db)
        {
            _db = db;
        }

        public bool Add(Task e)
        {
            _db.Add(e);
            return (_db.SaveChanges() > 0); ;
        }

        public bool Delete(long id)
        {
            var otp = (from u in _db.Tasks where u.Id == id select u).FirstOrDefault();
            if (otp != null)
            {
                _db.Tasks.Remove(otp);
            }
            return (_db.SaveChanges() > 0);
        }

        public bool Edit(Task e)
        {
            _db.Update<Task>(e);
            return (_db.SaveChanges() > 0);
        }

        public List<Task> Get()
        {
            throw new NotImplementedException();
        }

        public Task Get(long id)
        {
            return (from u in _db.Tasks where u.Id == id select u).FirstOrDefault();
        }

        public List<Task> GetForProject(long projectId)
        {
            var tasks=(from t in _db.Tasks where t.ProjectId == projectId select t).ToList();
            return tasks;
        }
        public List<Task> GetForAssignee(long projectId, long assignedTo)
        {
            var tasks = (from t in _db.Tasks where t.ProjectId == projectId && t.AssignedTo == assignedTo select t).ToList();
            return tasks;
        }
    }
}
