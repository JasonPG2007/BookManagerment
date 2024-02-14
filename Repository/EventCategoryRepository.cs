using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EventCategoryRepository : IEventCategoryRepository
    {
        public bool DeleteCategory(int id) => EventCategoryDAO.Instance.DeleteCategory(id);

        public IEnumerable<EventCategory> GetEventCategory() => EventCategoryDAO.Instance.GetEventCategory();

        public EventCategory GetEventCategoryById(int id) => EventCategoryDAO.Instance.GetEventCategoryById(id);

        public bool InsertCategory(EventCategory category) => EventCategoryDAO.Instance.InsertCategory(category);

        public bool UpdateCategory(EventCategory category) => EventCategoryDAO.Instance.UpdateCategory(category);
    }
}
