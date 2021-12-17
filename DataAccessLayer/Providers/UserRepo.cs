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
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(User e)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            return _db.Users.ToList();
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
