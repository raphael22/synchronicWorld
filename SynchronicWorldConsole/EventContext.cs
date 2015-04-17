using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SynchronicWorldConsole.ServiceReference1;

namespace SynchronicWorldConsole
{
    public class EventContext
    {
        public void ShowEventMenu(IService1 channel)
        {
            Console.WriteLine("****** SyncronicWorld ******");
            Console.WriteLine("");
            Console.WriteLine("> Events Menu");
            Console.WriteLine("1 : Create Event");
            Console.WriteLine("2 : Retrieve All Event");
            Console.WriteLine("3 : Retrieve Event");
            Console.WriteLine("4 : Update Event");
            Console.WriteLine("5 : Delete Event");
            Console.WriteLine("");

            ShowEventMenuAction(channel);
        }

        public void ShowEventMenuAction(IService1 channel)
        {
            Console.WriteLine("");
            Console.Write(">> ");
            var line = Console.ReadLine();
            Console.WriteLine("");
            switch (line)
            {
                case "1":
                    CreateEvent(channel);
                    break;
                case "2":
                    GetAllEvents(channel);
                    break;
                case "3":
                    GetEvent(channel);
                    break;
                case "4":
                    UpdateEvent(channel);
                    break;
                case "5":
                    DeleteEvent(channel);
                    break;
            }
        }

        public void GetAllEvents(IService1 channel)
        {
            var events = channel.GetAllEvents();
            foreach (Event evenementAll in events)
            {
                Console.WriteLine("Name Event : " + evenementAll.Name + " adresse : " + evenementAll.Address + " description : " + evenementAll.Description + " date evenement : " + evenementAll.Date.ToString() + " type d'evenement : " + evenementAll.Type + " status : " + evenementAll.Status);
            }
            ShowEventMenuAction(channel);
        }

        public void CreateEvent(IService1 channel)
        {
            Console.Write("Evenement : ");
            var eventAdd = Console.ReadLine();

            Console.Write("Adresse : ");
            var adressAdd = Console.ReadLine();

            Console.Write("Description : ");
            var descAdd = Console.ReadLine();

            Console.Write("Temps d'evenement en format '1:05' correspond à 1h05 : ");
            var eventTimeAdd = Console.ReadLine();

            Console.Write("Type d'evenement 1:Party, 2:Lunch et 3:Diner : ");
            var eventTypeAdd = Console.ReadLine();

            EventType eventType;
            if (eventTypeAdd == "1")
                eventType = EventType.Party;
            else if (eventTypeAdd == "2")
                eventType = EventType.Lunch;
            else if (eventTypeAdd == "3")
                eventType = EventType.Diner;
            else
            {
                Console.WriteLine("Mauvaise syntaxe pour le type d'evenement 1=Party, 2=Lunch et 3=Diner.");
            }
            var date = new DateTime();
            //Event evenement = channel.AddEvent(eventAdd, adressAdd, descAdd, date, eventTimeAdd, eventType, EventStatus.Pending);

            ShowEventMenuAction(channel);
        }

        public void GetEvent(IService1 channel)
        {
            Console.Write("Evenement : ");
            var evenementName = Console.ReadLine();
            Event evenementGet = channel.EventRetrieve(evenementName);
            if (evenementGet == null)
                Console.WriteLine("Evènement trouvé.");
            else
                Console.WriteLine("Evènement pas trouvé.");


            ShowEventMenuAction(channel);
        }

        public void UpdateEvent(IService1 channel)
        {
            Console.Write("Evenement : ");
            var evenementName = Console.ReadLine();
            Event evenementGet = channel.EventRetrieve(evenementName);
            if (evenementGet == null)
            {
                Console.WriteLine("Evènement trouvé.");
                Console.Write("Evenement : ");
                var eventUpdate = Console.ReadLine();
                Console.Write("Adresse : ");
                var adressUpdate = Console.ReadLine();
                Console.Write("Description : ");
                var descUpdate = Console.ReadLine();
                Console.Write("Date  : ");
                var dateUpdate = Console.ReadLine();           //////// CHANGER SA!!!!!
                var date = new DateTime();
                Console.Write("Temps d'evenement en format '1:05' correspond à 1h05 : ");
                var eventTimeUpdate = Console.ReadLine();
                Console.Write("Type d'evenement 1:Party, 2:Lunch et 3:Diner : ");
                var eventTypeUpdate = Console.ReadLine();
                EventType eventType;
                if (eventTypeUpdate == "1")
                    eventType = EventType.Party;
                else if (eventTypeUpdate == "2")
                    eventType = EventType.Lunch;
                else if (eventTypeUpdate == "3")
                    eventType = EventType.Diner;
                else
                {
                    Console.WriteLine("Mauvaise syntaxe pour le type d'evenement 1=Party, 2=Lunch et 3=Diner.");
                }
                EventStatus eventStatus;
                Console.Write("Status d'evenement 1:Open, 2:Pending et 3:Close : ");
                var eventStatusUpdate = Console.ReadLine();
                if (eventStatusUpdate == "1")
                    eventStatus = EventStatus.Open;
                else if (eventStatusUpdate == "2")
                    eventStatus = EventStatus.Pending;
                else if (eventStatusUpdate == "3")
                    eventStatus = EventStatus.Closed;
                else
                {
                    Console.WriteLine("Mauvaise syntaxe pour le status d'evenement 1=Party, 2=Lunch et 3=Diner.");
                }
                //channel.EventUpdate(evenementGet, eventUpdate, adressUpdate, descUpdate, date, eventTimeUpdate, eventType, eventStatus);
                Console.WriteLine("Evènement changé.");
            }
            else
                Console.WriteLine("Evènement pas trouvé.");


            ShowEventMenuAction(channel);
        }
        public void DeleteEvent(IService1 channel)
        {

            Console.Write("Name : ");
            var evenementName = Console.ReadLine();
            bool getDelete = channel.EventDelete(evenementName);
            if (getDelete == true)
                Console.WriteLine("Evènement trouvé et supprimé.");
            else
                Console.WriteLine("Evènement pas trouvé.");


            ShowEventMenuAction(channel);
        }
    }

    
}
