using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.AuthServices
{
    public class IdFromTokenService
    {
        public long GetId(string TOKEN)
        {
            var keys = new List<string>();
            keys.Add("Id");
            var myClaims = new TokenService().ValidateToken(TOKEN, keys);
            if(myClaims != null)
            {
                return Convert.ToInt64(myClaims["Id"].ToString());
            }
            return -1;
        }
    }
}
