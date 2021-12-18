using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Providers;
using EntityLayer.Models.User;

namespace LogicLayer.DbServices
{
    public class OtpService
    {
        public static bool Add(UserOtpModel userOtpModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserOtpModel, Otp>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Otp>(userOtpModel);
            return DataAccessFactory.OtpDataAccess().Add(data);
        }
        public static bool Delete(long id)
        {
            return DataAccessFactory.OtpDataAccess().Delete(id);
        }
        public static UserOtpModel GetByOtp(string otp)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Otp, UserOtpModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserOtpModel>(DataAccessFactory.OtpDataAccess().GetByOtp(otp));
        }
    }
}
