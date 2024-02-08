using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EventDAO
    {
        private readonly BookContext db;
        private static EventDAO instance = null;
        private static readonly object Lock = new object();
        public static EventDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new EventDAO();
                    }
                    return instance;
                }
            }
        }
        public EventDAO()
        {
            db = new BookContext();
        }
        public IEnumerable<Event> GetEvents()
        {
            using var context = new BookContext();
            var list = context.Events.ToList();
            return list;
        }
        public Event GetEventById(int id)
        {
            using var context = new BookContext();
            var events = context.Events.FirstOrDefault(e => e.EventId == id);
            return events;
        }
        public bool InsertEvent(Event events)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool UpdateEvent(Event events)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                var checkContains = GetEventById(events.EventId);
                if (checkContains != null)
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool DeleteEvent(int id)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                var checkContains = GetEventById(id);
                if (checkContains != null)
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
    }
}
