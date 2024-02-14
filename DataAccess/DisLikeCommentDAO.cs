using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DisLikeCommentDAO
    {
        private static DisLikeCommentDAO instance = null;
        private static readonly object Lock = new object();
        public static DisLikeCommentDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new DisLikeCommentDAO();
                    }
                    return instance;
                }
            }
        }

        #region GetDisLikes function
        public IEnumerable<DisLikeComment> GetDisLikes()
        {
            using var context = new BookContext();
            var list = context.DisLikeComments.ToList();
            return list;
        }
        #endregion

        #region GetDisLikeById function
        public DisLikeComment GetDisLikeById(int id)
        {
            using var context = new BookContext();
            var like = context.DisLikeComments.FirstOrDefault(l => l.DisLikeId == id);
            return like;
        }
        #endregion

        #region InsertDisLike function
        public bool InsertDisLike(DisLikeComment disLike)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                context.DisLikeComments.Add(disLike);
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

        #region UpdateDisLike function
        public bool UpdateDisLike(DisLikeComment disLike)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetDisLikeById(disLike.DisLikeId);
            if (checkContains != null)
            {
                try
                {
                    context.Entry<DisLikeComment>(disLike).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        #region DeleteDisLike function
        public bool DeleteDisLike(int id)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetDisLikeById(id);
            if (checkContains != null)
            {
                try
                {
                    context.DisLikeComments.Remove(checkContains);
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
