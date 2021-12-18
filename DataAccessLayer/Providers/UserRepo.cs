using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class UserRepo : IUserProvider
    {
        QuicklyContext _db;
        public UserRepo(QuicklyContext db)
        {
            _db = db;
        }

        public bool Add(User e)
        {
            _db.Add(e);
            return (_db.SaveChanges() > 0); ;
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(User e)
        {
            _db.Update<User>(e);
            return (_db.SaveChanges() > 0);
        }

        public List<User> Get()
        {
            return _db.Users.ToList();
        }

        public List<User> GetMembers(long projectId)
        {
            var users = (from u in _db.Users join f in _db.FkProjectsUsers on u.Id equals f.UserId where f.ProjectId == projectId && f.IsOwner == false select u).ToList();
            return users;
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            return (from u in _db.Users where u.Email == email select u).FirstOrDefault();
        }

        public User GetUserById(long id)
        {
            return (from u in _db.Users where u.Id == id select u).FirstOrDefault();
        }

        public bool IsEmailTaken(string email)
        {
            var user = (from u in _db.Users where u.Email == email select u).FirstOrDefault();
            return user != null;
        }

        public bool IsPhoneTaken(string phone)
        {
            var user = (from u in _db.Users where u.Phone == phone select u).FirstOrDefault();
            return user != null;
        }

        public bool Verify(long id)
        {
            var user = _db.Users.Find(id);
            user.IsVerified = true;
            return (_db.SaveChanges() > 0);
        }
    }
}
