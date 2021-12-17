using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Providers;

namespace DataAccessLayer.IProviders
{
    public interface IUserProvider : IEntityProvider<User, long>
    {
        public bool IsEmailTaken(string email);
        public bool IsPhoneTaken(string phone);
        public User GetUserByEmail(string email);
        public bool Verify(long id);
    }
}
