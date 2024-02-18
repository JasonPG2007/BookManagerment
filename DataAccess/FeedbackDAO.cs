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
        private readonly BookContext db;
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
        public FeedbackDAO()
        {
            db = new BookContext();
        }

        #region GetFeedbacksTop function
        public IEnumerable<Feedback> GetFeedbacksTop()
        {
            var list = (from a in db.Feedbacks
                        join b in db.Accounts
                        on a.AccountId equals b.AccountId
                        join c in db.Users
                        on b.UserId equals c.UserId
                        orderby a.DateFeedBack descending
                        select new Feedback
                        {
                            FeedbackId = a.FeedbackId,
                            DateFeedBack = a.DateFeedBack,
                            Content = a.Content,
                            Avatar = c.Picture,
                            UserName = b.UserName,
                            Evaluate = a.Evaluate,
                            ServiceId = a.ServiceId,
                            AccountId = a.AccountId,
                        }).Take(3);
            return list;
        }
        #endregion

        #region GetFeedBacks function
        public IEnumerable<Feedback> GetFeedbacks()
        {
            var list = from a in db.Feedbacks
                       join b in db.Accounts
                       on a.AccountId equals b.AccountId
                       join c in db.Users
                       on b.UserId equals c.UserId
                       orderby a.DateFeedBack descending
                       select new Feedback
                       {
                           FeedbackId = a.FeedbackId,
                           DateFeedBack = a.DateFeedBack,
                           Content = a.Content,
                           Avatar = c.Picture,
                           UserName = b.UserName,
                           Evaluate = a.Evaluate,
                           ServiceId = a.ServiceId,
                           AccountId = a.AccountId,
                       };
            return list;
        }
        #endregion

        #region GetFeedBackById function
        public Feedback GetFeedBackById(int id)
        {
            var feedback = (from a in db.Feedbacks
                            join b in db.Accounts
                            on a.AccountId equals b.AccountId
                            join c in db.Users
                            on b.UserId equals c.UserId
                            where a.FeedbackId == id
                            select new Feedback
                            {
                                FeedbackId = a.FeedbackId,
                                DateFeedBack = a.DateFeedBack,
                                Content = a.Content,
                                Avatar = c.Picture,
                                UserName = b.UserName,
                                Evaluate = a.Evaluate,
                                ServiceId = a.ServiceId,
                                AccountId = a.AccountId,
                            }).FirstOrDefault();
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
