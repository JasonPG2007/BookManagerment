using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEventCategoryRepository
    {
        public IEnumerable<EventCategory> GetEventCategory();
        public EventCategory GetEventCategoryById(int id);
        public bool InsertCategory(EventCategory category);
        public bool UpdateCategory(EventCategory category);
        public bool DeleteCategory(int id);
    }
}
