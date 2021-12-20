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
            _db.Add(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(FkProjectsUser e)
        {
            _db.Update<FkProjectsUser>(e);
            return (_db.SaveChanges() > 0);
        }

        public List<FkProjectsUser> Get()
        {
            throw new NotImplementedException();
        }

        public FkProjectsUser Get(long id)
        {
            throw new NotImplementedException();
        }
        public FkProjectsUser GetOne(long userId, long projectId)
        {
            var fk = (from f in _db.FkProjectsUsers where f.UserId == userId && f.ProjectId == projectId select f).FirstOrDefault();
            return fk;
        }
    }
}
