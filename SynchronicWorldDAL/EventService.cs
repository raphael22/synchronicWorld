using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldDAL
{
    public class EventService
    {
        private static SynchronicWorldContext context = new SynchronicWorldContext();

        public Event addEvent(Event evenement){
            context.Events.Add(evenement);
            context.SaveChanges();
            return evenement;
        }

        public List<Event> getAllEvent()
        {
            var events = from e in context.Events select e;
            return events.ToList();
        }
        public List<Event> getListEventBetweenDate(DateTime date1, DateTime date2)
        {
                var events = from e in context.Events where e.Date>=date1 && e.Date<=date2 select e;
                return events.ToList();
        }

        public Event updateEvent(Event evenement)
        {
            context.Entry(evenement).State = EntityState.Modified;
            context.SaveChanges();
            return evenement;
        }

        public Event getEvent(string name)
        {
            var events = (from e in context.Events where e.Name==name select e).FirstOrDefault();
            return events;
        }

        public bool removeEvent(Event evenement)
        {
            context.Events.Remove(context.Events.Find(evenement.Id));
            context.SaveChanges();
            return true;
        }


        public bool getEventExist(string name, DateTime date)
        {
            var evenement = from e in context.Events where e.Name == name && e.Date == date select e;
            if (evenement == null)
                return false;
            return true;
        }


        public List<Event> getEventTypeOrStatus(EventType eventType, EventStatus eventStatus)
        {
            var events = from e in context.Events where e.Type == eventType || e.Status == eventStatus select e;
            return events.ToList();
        }

        public bool deleteAllEventClosed()
        {
            var eventClosed=from e in context.Events where e.Status==EventStatus.Closed select e;
            List<Event> listEventClosed = eventClosed.ToList();
            if (listEventClosed == null)
                return false;
            foreach (Event evenement in listEventClosed)
            {
                removeEvent(evenement);
            }
            return true;
        }


        public bool updateAllPending()
        {
            var eventPending = from e in context.Events where e.Status == EventStatus.Pending select e;
            List<Event> listEventPending = eventPending.ToList();
            if (listEventPending == null)
                return false;
            foreach (Event evenement in listEventPending)
            {
                evenement.Status = EventStatus.Open;
                updateEvent(evenement);
            }
            return true;
        }
    }
}
