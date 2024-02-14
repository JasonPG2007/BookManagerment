using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEventRepository
    {
        public IEnumerable<Event> GetEvents();
        public IEnumerable<EventViewModel> GetEventAndAccount();
        public Event GetEventById(int id);
        public bool InsertEvent(Event events);
        public bool UpdateEvent(Event events);
        public bool DeleteEvent(int id);
    }
}
