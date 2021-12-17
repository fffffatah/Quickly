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
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Task e)
        {
            throw new NotImplementedException();
        }

        public List<Task> Get()
        {
            throw new NotImplementedException();
        }

        public Task Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
