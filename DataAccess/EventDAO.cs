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
            var list = from a in db.Events
                       join b in db.Accounts
                       on a.AccountId equals b.AccountId
                       join c in db.Accounts
                       on b.AccountId equals c.AccountId
                       join d in db.Users
                       on c.UserId equals d.UserId
                       select new Event
                       {
                           AccountId = c.AccountId,
                           EventId = a.EventId,
                           CategoryId = a.CategoryId,
                           DateCreated = a.DateCreated,
                           EventContent = a.EventContent,
                           EventDescription = a.EventDescription,
                           EventName = a.EventName,
                           NumberOfParticipants = a.NumberOfParticipants,
                           Picture = a.Picture,
                           UserName = c.UserName,
                           Address = d.Address,
                           Region = d.Region,
                           City = d.City,
                       };
            return list;
        }
        public IEnumerable<EventViewModel> GetEventAndAccount()
        {
            var list = from a in db.Events
                       join b in db.Accounts
                       on a.AccountId equals b.AccountId
                       join c in db.Accounts
                       on b.AccountId equals c.AccountId
                       select new EventViewModel
                       {
                           AccountId = b.AccountId,
                           EventId = a.EventId,
                           CategoryId = a.CategoryId,
                           DateCreated = a.DateCreated,
                           EventContent = a.EventContent,
                           EventDescription = a.EventDescription,
                           EventName = a.EventName,
                           NumberOfParticipants = a.NumberOfParticipants,
                           Picture = a.Picture,
                           UserName = b.UserName
                       };
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
