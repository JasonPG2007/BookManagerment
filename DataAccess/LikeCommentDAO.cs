using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LikeCommentDAO
    {
        private static LikeCommentDAO instance = null;
        private readonly BookContext db;
        private static readonly object Lock = new object();
        public static LikeCommentDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new LikeCommentDAO();
                    }
                    return instance;
                }
            }
        }
        public LikeCommentDAO()
        {
            db = new BookContext();
        }

        #region GetAcountLike function
        public IEnumerable<LikeComment> GetAcountLike(int idAccount)
        {
            var account = from a in db.Accounts
                          join b in db.Events
                          on a.AccountId equals b.AccountId
                          join c in db.Comments
                          on b.EventId equals c.EventId
                          join d in db.LikeComments
                          on c.CommentId equals d.CommentId
                          where a.AccountId == idAccount
                          select new LikeComment
                          {
                              UserName = a.UserName,
                              DateLike = d.DateLike
                          };
            return account;
        }
        #endregion

        #region GetLikes function
        public IEnumerable<LikeComment> GetLikes()
        {
            using var context = new BookContext();
            var list = context.LikeComments.ToList();
            return list;
        }
        #endregion

        #region GetLikeById function
        public LikeComment GetLikeById(int id)
        {
            using var context = new BookContext();
            var like = context.LikeComments.FirstOrDefault(l => l.LikeId == id);
            return like;
        }
        #endregion

        #region InsertLike function
        public bool InsertLike(LikeComment like)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                context.LikeComments.Add(like);
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
        #endregion

        #region UpdateLike function
        public bool UpdateLike(LikeComment like)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetLikeById(like.LikeId);
            if (checkContains != null)
            {
                try
                {
                    context.Entry<LikeComment>(like).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        #endregion

        #region DeleteLike function
        public bool DeleteLike(int id)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetLikeById(id);
            if (checkContains != null)
            {
                try
                {
                    context.LikeComments.Remove(checkContains);
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
        #endregion
    }
}
