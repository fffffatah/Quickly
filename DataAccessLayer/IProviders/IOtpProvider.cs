using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Providers;

namespace DataAccessLayer.IProviders
{
    public interface IOtpProvider:IEntityProvider<Otp, long>
    {
        public Otp GetByOtp(string otp);
    }
}
