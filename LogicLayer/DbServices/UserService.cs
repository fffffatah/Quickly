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
    public class UserService
    {
        public static bool Add(UserRegistrationModel userRegistrationModel)
        {
            userRegistrationModel.Pass = BCrypt.Net.BCrypt.HashPassword(userRegistrationModel.Pass, BCrypt.Net.BCrypt.GenerateSalt());
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserRegistrationModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(userRegistrationModel);
            return DataAccessFactory.UserDataAccess().Add(data);
        }
        public static bool Update(UserUpdateModel userUpdateModel, long id)
        {
            var user = DataAccessFactory.UserDataAccess().GetUserById(id);
            user.ProfileImageUrl = (userUpdateModel.ProfileImageUrl != null ? userUpdateModel.ProfileImageUrl : user.ProfileImageUrl);
            user.FullName=(userUpdateModel.FullName != null ? userUpdateModel.FullName : user.FullName);
            return DataAccessFactory.UserDataAccess().Edit(user);
        }
        public static bool ResetPass(UserResetPassModel userResetPassModel, long id)
        {
            var user = DataAccessFactory.UserDataAccess().GetUserById(id);
            user.Pass = BCrypt.Net.BCrypt.HashPassword(userResetPassModel.Pass, BCrypt.Net.BCrypt.GenerateSalt());
            return DataAccessFactory.UserDataAccess().Edit(user);
        }
        public static bool Verify(long id)
        {
            return DataAccessFactory.UserDataAccess().Verify(id);
        }
        public static List<UserModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());
        }

        public static UserModel GetByEmail(string email)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().GetUserByEmail(email));
        }

        public static UserModel GetById(long id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().GetUserById(id));
        }

        public static UserModel Login(string email, string pass)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().GetUserByEmail(email));
            if(data == null)
            {
                return null;
            }
            return BCrypt.Net.BCrypt.Verify(pass, data.Pass) ? data : null;
        }
    }
}
