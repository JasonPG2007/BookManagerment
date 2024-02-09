using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentRepository : ICommentRepository
    {
        public bool DeleteComment(int id) => CommentDAO.Instance.DeleteComment(id);

        public Comment GetCommentById(int id) => CommentDAO.Instance.GetCommentById(id);

        public IEnumerable<Comment> GetComments() => CommentDAO.Instance.GetComments();

        public bool InsertComment(Comment comment) => CommentDAO.Instance.InsertComment(comment);

        public bool UpdateComment(Comment comment) => CommentDAO.Instance.UpdateComment(comment);
        public IEnumerable<Comment> GetCommentByEventId(int id) => CommentDAO.Instance.GetCommentByEventId(id);
    }
}
