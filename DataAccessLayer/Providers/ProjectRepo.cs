using DataAccessLayer.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Providers
{
    public class ProjectRepo : IProjectProvider
    {
        QuicklyContext _db;
        public ProjectRepo(QuicklyContext db)
        {
            _db = db;
        }

        public bool Add(Project e)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Project e)
        {
            throw new NotImplementedException();
        }

        public List<Project> Get()
        {
            throw new NotImplementedException();
        }

        public Project Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
