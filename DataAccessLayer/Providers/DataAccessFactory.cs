using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class DataAccessFactory
    {
        static QuicklyContext _db;
        static DataAccessFactory()
        {
            _db = new QuicklyContext();
        }
        public static IOtpProvider OtpDataAccess()
        {
            return new OtpRepo(_db);
        }
        public static IUserProvider UserDataAccess()
        {
            return new UserRepo(_db);
        }
    }
}
