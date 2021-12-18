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
        public static IProjectProvider ProjectDataAccess()
        {
            return new ProjectRepo(_db);
        }
        public static ITaskProvider TaskDataAccess()
        {
            return new TaskRepo(_db);
        }
        public static ICommentProvider CommentDataAccess()
        {
            return new CommentRepo(_db);
        }
        public static IFKProjectsUserProvider FKDataAccess()
        {
            return new FKProjectsUserRepo(_db);
        }
        public static ITaskAttachmentProvider TaskAttachmentDataAccess()
        {
            return new TaskAttachmentRepo(_db);
        }
        public static ICommentAttachmentProvider CommentAttachmentDataAccess()
        {
            return new CommentAttachmentRepo(_db);
        }
    }
}
