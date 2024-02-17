using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public IEnumerable<Feedback> GetFeedbacks() => FeedbackDAO.Instance.GetFeedbacks();
        public Feedback GetFeedBackById(int id) => FeedbackDAO.Instance.GetFeedBackById(id);

        public bool InsertFeedBack(Feedback feedback) => FeedbackDAO.Instance.InsertFeedBack(feedback);

        public bool UpdateFeedBack(Feedback feedback) => FeedbackDAO.Instance.UpdateFeedBack(feedback);

        public bool DeleteFeedBack(int id) => FeedbackDAO.Instance.DeleteFeedBack(id);
        public IEnumerable<Feedback> GetFeedbacksTop() => FeedbackDAO.Instance.GetFeedbacksTop();
    }
}
