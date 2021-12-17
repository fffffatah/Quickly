using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IProviders;

namespace DataAccessLayer.Providers
{
    public class CommentRepo : ICommentProvider
    {
        QuicklyContext _db;
        public CommentRepo(QuicklyContext db)
        {
            _db = db;
        }

        public bool Add(Comment e)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Comment e)
        {
            throw new NotImplementedException();
        }

        public List<Comment> Get()
        {
            throw new NotImplementedException();
        }

        public Comment Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
