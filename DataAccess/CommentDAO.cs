using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommentDAO
    {
        private static CommentDAO instance = null;
        private static readonly object Lock = new object();
        private readonly BookContext db;
        public CommentDAO()
        {
            db = new BookContext();
        }
        public static CommentDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new CommentDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Comment> GetComments()
        {
            using var context = new BookContext();
            var list = context.Comments.ToList();
            return list;
        }
        public Comment GetCommentById(int id)
        {
            using var context = new BookContext();
            var comment = context.Comments.FirstOrDefault(c => c.CommentId == id);
            return comment;
        }
        public IEnumerable<Comment> GetCommentByEventId(int id)
        {
            var comment = from a in db.Comments
                          join b in db.Events
                          on a.EventId equals b.EventId
                          join c in db.Accounts
                          on b.AccountId equals c.AccountId
                          join d in db.Users
                          on c.UserId equals d.UserId
                          //join e in db.LikeComments
                          //on a.CommentId equals e.CommentId
                          //join f in db.DisLikeComments
                          //on a.CommentId equals f.CommentId
                          where b.EventId == id
                          select new Comment
                          {
                              Content = a.Content,
                              DateComment = a.DateComment,
                              AccountId = c.AccountId,
                              CommentId = a.CommentId,
                              Interact = a.Interact,
                              UserName = c.UserName,
                              Picture = d.Picture,
                              //Like = e.Quantity,
                              //DisLike = f.Quantity
                          };
            return comment;
        }
        public bool InsertComment(Comment comment)
        {
            using var context = new BookContext();
            bool status = false;
            try
            {
                context.Comments.Add(comment);
                int isSuccessfully = context.SaveChanges();
                if (isSuccessfully > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool UpdateComment(Comment comment)
        {
            using var context = new BookContext();
            bool status = false;
            var checkContains = GetCommentById(comment.CommentId);
            if (checkContains != null)
            {
                try
                {
                    context.Entry<Comment>(comment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    int isSuccessfully = context.SaveChanges();
                    if (isSuccessfully > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return status;
        }
        public bool DeleteComment(int id)
        {
            using var context = new BookContext();
            bool status = false;
            var checkContains = GetCommentById(id);
            if (checkContains != null)
            {
                try
                {
                    context.Comments.Remove(checkContains);
                    int isSuccessfully = context.SaveChanges();
                    if (isSuccessfully > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return status;
        }
    }
}
