using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICommentRepository
    {
        public IEnumerable<Comment> GetComments();
        public Comment GetCommentById(int id);
        public bool InsertComment(Comment comment);
        public bool UpdateComment(Comment comment);
        public bool DeleteComment(int id);
        public IEnumerable<Comment> GetCommentByEventId(int id);
    }
}
