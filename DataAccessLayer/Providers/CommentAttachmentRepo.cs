using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class CommentAttachmentRepo : ICommentAttachmentProvider
    {
        QuicklyContext _db;
        public CommentAttachmentRepo(QuicklyContext db)
        {
            _db = db;
        }

        public bool Add(CommentAttachment e)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(CommentAttachment e)
        {
            throw new NotImplementedException();
        }

        public List<CommentAttachment> Get()
        {
            throw new NotImplementedException();
        }

        public CommentAttachment Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
