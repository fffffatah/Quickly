using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class FKProjectsUserRepo : IFKProjectsUserProvider
    {

        QuicklyContext _db;
        public FKProjectsUserRepo(QuicklyContext db)
        {
            _db = db;
        }

        public bool Add(FkProjectsUser e)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(FkProjectsUser e)
        {
            throw new NotImplementedException();
        }

        public List<FkProjectsUser> Get()
        {
            throw new NotImplementedException();
        }

        public FkProjectsUser Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
