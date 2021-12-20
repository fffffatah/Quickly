using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntityLayer.Models;
using DataAccessLayer.Providers;

namespace LogicLayer.DbServices
{
    public class FKProjectsUserService
    {
        public static bool Add(FKProjectsUsersModel fKProjectsUsersModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<FKProjectsUsersModel, FkProjectsUser>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<FkProjectsUser>(fKProjectsUsersModel);
            return DataAccessFactory.FKDataAccess().Add(data);
        }
        public static bool Edit(FKProjectsUsersModel fKProjectsUsersModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<FKProjectsUsersModel, FkProjectsUser>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<FkProjectsUser>(fKProjectsUsersModel);
            return DataAccessFactory.FKDataAccess().Edit(data);
        }
        public static FKProjectsUsersModel GetOne(long userId, long projectId)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<FkProjectsUser, FKProjectsUsersModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<FKProjectsUsersModel>(DataAccessFactory.FKDataAccess().GetOne(userId, projectId));
        }
    }
}
