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
            _db.Add(e);
            return (_db.SaveChanges() > 0);
        }
        public long AddGetId(Project e)
        {
            _db.Add(e);
            if((_db.SaveChanges() > 0))
            {
                return e.Id;
            }
            return -1;
        }

        public bool Delete(long id)
        {
            var otp = (from u in _db.Projects where u.Id == id select u).FirstOrDefault();
            if (otp != null)
            {
                _db.Projects.Remove(otp);
            }
            return (_db.SaveChanges() > 0);
        }

        public bool Edit(Project e)
        {
            _db.Update<Project>(e);
            return (_db.SaveChanges() > 0);
        }

        public List<Project> Get()
        {
            throw new NotImplementedException();
        }

        public Project Get(long id)
        {
            return (from u in _db.Projects where u.Id == id select u).FirstOrDefault();
        }

        public List<Project> GetForUser(long userId)
        {
            var projects = (from p in _db.Projects join f in _db.FkProjectsUsers on p.Id equals f.ProjectId where f.UserId == userId select p).ToList();
            return projects;
        }

        public List<Project> GetForOwner(long userId)
        {
            var projects = (from p in _db.Projects join f in _db.FkProjectsUsers on p.Id equals f.ProjectId where f.UserId == userId && f.IsOwner == true select p).ToList();
            return projects;
        }

        public List<Project> GetForMember(long userId)
        {
            var projects = (from p in _db.Projects join f in _db.FkProjectsUsers on p.Id equals f.ProjectId where f.UserId == userId && f.IsOwner == false select p).ToList();
            return projects;
        }
    }
}
