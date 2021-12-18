using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.User
{
    public class UserOtpModel
    {
        public long Id { get; set; }
        public string? Otp1 { get; set; }
        public long UserId { get; set; }
    }
}
