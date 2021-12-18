using AutoMapper;
using EntityLayer.Models.Task;
using DataAccessLayer.Providers;

namespace LogicLayer.DbServices
{
    public class TaskService
    {
        public static bool Add(CreateTaskModel createTaskModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateTaskModel, DataAccessLayer.Providers.Task>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DataAccessLayer.Providers.Task>(createTaskModel);
            return DataAccessFactory.TaskDataAccess().Add(data);
        }
        public static bool Delete(long taskId)
        {
            return DataAccessFactory.TaskDataAccess().Delete(taskId);
        }
        public static List<TaskModel> Get(long projectId)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<DataAccessLayer.Providers.Task, TaskModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TaskModel>>(DataAccessFactory.TaskDataAccess().GetForProject(projectId));
        }
        public static List<TaskModel> GetForAssignee(long projectId, long assignedTo)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<DataAccessLayer.Providers.Task, TaskModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TaskModel>>(DataAccessFactory.TaskDataAccess().GetForAssignee(projectId, assignedTo));
        }
        public static TaskModel GetById(long taskId)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<DataAccessLayer.Providers.Task, TaskModel>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<TaskModel>(DataAccessFactory.TaskDataAccess().Get(taskId));
        }
        public static bool ChangeStatus(string taskStatus, long taskId)
        {
            var mytask = DataAccessFactory.TaskDataAccess().Get(taskId);
            if (mytask != null)
            {
                mytask.TaskStatus = taskStatus;
                return DataAccessFactory.TaskDataAccess().Edit(mytask);
            }
            return false;
        }
    }
}
