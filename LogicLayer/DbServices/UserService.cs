using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Providers;

namespace LogicLayer.DbServices
{
    public class UserService
    {
        public static List<User> Get()
        {
            return DataAccessFactory.UserDataAccess().Get();
        }
    }
}
