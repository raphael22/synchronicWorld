using Models;
using SynchronicWorldDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SynchronicWorldWcfServ
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {

        private PersonService personService=new PersonService();
        private EventService eventService = new EventService();

        public Person AddPerson(string name, string nickName)
        {
            var person = new Person() { Name = name, NickName = nickName };
            try
            {
                //_persons.Add(person);
                personService.addPerson(person);

            }
            catch (Exception ex)
            {
                //

            }

            return person;
        }

        public Person PersonRetrieve(string name)
        {
            Person person = personService.getPerson(name);
            return person;
        }

        public Person PersonUpdate(Person person,string name,string nickname)
        {
            person.Name = name;
            person.NickName = nickname;
            personService.updatePerson(person);
            return person;
        }

        public bool PersonDelete(string name)
        {
            Person person = personService.getPerson(name);
            if (person == null)
                return false;
            personService.removePerson(person);
            return true;
        }

        public List<Person> GetAllPersons()
        {
            List<Person> persons = personService.getAllPerson();
            return persons;
        }

        public Event AddEvent(string name, string address, string description, DateTime date, string time, Models.EventType type, Models.EventStatus status)
        {
            var evenenement=new Event(){ Name=name, Address=address, Date=date, Description=description, Time=time, Type=type, Status=status};
            eventService.addEvent(evenenement);
            return evenenement;
        }
        ///*, string address, string description, DateTime date, string time, Models.EventType type, Models.EventStatus status*/
        public Event EventRetrieve(string name)
        {
            var evenement= eventService.getEvent(name);
            return evenement;
        }

        public bool EventUpdate(Event evenement,string name, string address, string description, DateTime date, string time, Models.EventType type, Models.EventStatus status)
        {
            if (evenement == null)
            {
                return false;
            }
            evenement.Name = name;
            evenement.Address = address;
            evenement.Description = description;
            evenement.Date = date;
            evenement.Time = time;
            evenement.Type = type;
            evenement.Status = status;
            eventService.updateEvent(evenement);
            return true;
        }

        public bool EventDelete(string name)
        {
            Event evenement= eventService.getEvent(name);
            if (evenement == null)
                return false;
            eventService.removeEvent(evenement);
            return true;
        }

        public bool EventExists(string name, DateTime date)
        {
            bool  evenement=eventService.getEventExist(name, date);
            return evenement;
        }

        public List<Event> EventDateRetrieve(DateTime date1, DateTime date2)
        {
            List<Event> events=eventService.getListEventBetweenDate(date1, date2);
            return events;
        }

        public List<Event> EventTypeOrStatusRetrieve(Models.EventType type, Models.EventStatus status)
        {
            List<Event> events = eventService.getEventTypeOrStatus(type, status);
            return events;
        }

        public bool EventClosedDelete()
        {
            bool eventClosed = eventService.deleteAllEventClosed();
            if (eventClosed == true)
                return true;
            else
                return false;
        }

        public bool EventPendingUpdate()
        {
            bool eventPending = eventService.updateAllPending();
            if (eventPending == true)
                return true;
            else
                return false;
        }

        public List<Event> GetAllEvents()
        {
            var events=eventService.getAllEvent();
            return events;
        }

        public Contribution AddContribution(string name, int quantity, Models.ContributionType type)
        {
            throw new NotImplementedException();
        }

        public List<Contribution> GetAllContributions()
        {
            throw new NotImplementedException();
        }
    }
}
