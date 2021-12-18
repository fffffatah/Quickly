using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntityLayer.Models.Project;
using DataAccessLayer.Providers;

namespace LogicLayer.DbServices
{
    public class ProjectService
    {
        public static bool Add(ProjectCreateModel projectCreateModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ProjectCreateModel, Project>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Project>(projectCreateModel);
            return DataAccessFactory.ProjectDataAccess().Add(data);
        }
        public static long AddGetId(ProjectCreateModel projectCreateModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ProjectCreateModel, Project>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Project>(projectCreateModel);
            return DataAccessFactory.ProjectDataAccess().AddGetId(data);
        }
        public static bool Update(ProjectUpdateModel projectUpdateModel, long id)
        {
            var project = DataAccessFactory.ProjectDataAccess().Get(id);
            project.ProjectName = projectUpdateModel.ProjectName;
            project.ProjectDetails = projectUpdateModel.ProjectDetails;
            project.ProjectImageUrl = (projectUpdateModel.ProjectImageUrl != null ? projectUpdateModel.ProjectImageUrl : project.ProjectImageUrl);
            return DataAccessFactory.ProjectDataAccess().Edit(project);
        }
        public static bool Delete(long id)
        {
            return DataAccessFactory.ProjectDataAccess().Delete(id);
        }
        public static ProjectModel Get(long id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Project, ProjectModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ProjectModel>(DataAccessFactory.ProjectDataAccess().Get(id));
        }
        public static List<ProjectModel> GetForUser(long userId)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Project, ProjectModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ProjectModel>>(DataAccessFactory.ProjectDataAccess().GetForUser(userId));
        }
        public static List<ProjectModel> GetForOwner(long userId)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Project, ProjectModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ProjectModel>>(DataAccessFactory.ProjectDataAccess().GetForOwner(userId));
        }
        public static List<ProjectModel> GetForMember(long userId)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Project, ProjectModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ProjectModel>>(DataAccessFactory.ProjectDataAccess().GetForMember(userId));
        }
    }
}
