using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IFeedbackRepository
    {
        public IEnumerable<Feedback> GetFeedbacks();
        public Feedback GetFeedBackById(int id);
        public bool InsertFeedBack(Feedback feedback);
        public bool UpdateFeedBack(Feedback feedback);
        public bool DeleteFeedBack(int id);
    }
}
