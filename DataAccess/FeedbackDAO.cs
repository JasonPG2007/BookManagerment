using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FeedbackDAO
    {
        private static FeedbackDAO instance = null;
        private static readonly object Lock = new object();
        public static FeedbackDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new FeedbackDAO();
                    }
                    return instance;
                }
            }
        }

        #region GetFeedBacks function
        public IEnumerable<Feedback> GetFeedbacks()
        {
            using var context = new BookContext();
            var list = context.Feedbacks.ToList();
            return list;
        }
        #endregion

        #region GetFeedBackById function
        public Feedback GetFeedBackById(int id)
        {
            using var context = new BookContext();
            var feedback = context.Feedbacks.FirstOrDefault(s => s.FeedbackId == id);
            return feedback;
        }
        #endregion

        #region InsertFeedBack function
        public bool InsertFeedBack(Feedback feedback)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                context.Add(feedback);
                int isSuccessfullt = context.SaveChanges();
                if (isSuccessfullt > 0)
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

        #region UpdateFeedBack function
        public bool UpdateFeedBack(Feedback feedback)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetFeedBackById(feedback.FeedbackId);
            try
            {
                if (checkContains != null)
                {
                    context.Entry<Feedback>(feedback).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    int isSuccessfullt = context.SaveChanges();
                    if (isSuccessfullt > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        #endregion

        #region DeleteFeedBack function
        public bool DeleteFeedBack(int id)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetFeedBackById(id);
            try
            {
                if (checkContains != null)
                {
                    context.Feedbacks.Remove(checkContains);
                    int isSuccessfullt = context.SaveChanges();
                    if (isSuccessfullt > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        #endregion
    }
}
