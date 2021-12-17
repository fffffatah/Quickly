using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class TaskAttachmentRepo :ITaskAttachmentProvider
    {
        QuicklyContext _db;
        public TaskAttachmentRepo(QuicklyContext db)
        {
            _db = db;
        }

        public bool Add(TaskAttachment e)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(TaskAttachment e)
        {
            throw new NotImplementedException();
        }

        public List<TaskAttachment> Get()
        {
            throw new NotImplementedException();
        }

        public TaskAttachment Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
