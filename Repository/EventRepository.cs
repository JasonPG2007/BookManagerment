using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EventRepository : IEventRepository
    {
        public IEnumerable<Event> GetEvents() => EventDAO.Instance.GetEvents();
    }
}
