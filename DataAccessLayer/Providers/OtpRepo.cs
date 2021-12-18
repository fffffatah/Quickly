using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class OtpRepo : IOtpProvider
    {
        QuicklyContext _db;
        public OtpRepo(QuicklyContext db)
        {
            _db = db;
        }
        public bool Add(Otp e)
        {
            _db.Add(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Delete(long id)
        {
            var otp = (from u in _db.Otps where u.Id == id select u).FirstOrDefault();
            if(otp != null)
            {
                _db.Otps.Remove(otp);
            }
            return (_db.SaveChanges() > 0);
        }

        public bool Edit(Otp e)
        {
            throw new NotImplementedException();
        }

        public List<Otp> Get()
        {
            throw new NotImplementedException();
        }

        public Otp Get(long id)
        {
            throw new NotImplementedException();
        }

        public Otp GetByOtp(string otp)
        {
            return (from u in _db.Otps where u.Otp1 == otp select u).FirstOrDefault();
        }
    }
}
