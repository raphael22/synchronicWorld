
using SynchronicWorldConsole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress address = new EndpointAddress(new Uri("http://localhost:65256/Service1.svc"));
                ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding, address);
                var channel = factory.CreateChannel();

                //Event evenement=channel.AddEvent("evenement","1 rue de l'event","description","23/04/2015","13h05",EventType.Party,EventStatus.Open);

                var userContext = new UserContext();
                var eventContext = new EventContext();

                ShowMenu(channel, userContext, eventContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOOPS");
                Console.ReadLine();
            }


        }

        private static void ShowMenu(IService1 channel,UserContext userContext,EventContext eventContext)
        {
            Console.WriteLine("****** SyncronicWorld ******");
            Console.WriteLine("");
            Console.WriteLine("> Menu");
            Console.WriteLine("1 : Users");
            Console.WriteLine("2 : Events ");
            Console.WriteLine("");
            /*Console.WriteLine("1 : Get all users ");
            Console.WriteLine("2 : Add users ");
            Console.WriteLine("3 : Remove users ");
            Console.WriteLine("4 : Update users ");
            Console.WriteLine("5 : Get user ");
            Console.WriteLine("6 : Add event ");
            Console.WriteLine("7 : Get all events ");
            Console.WriteLine("8 : Get event ");
            Console.WriteLine("9 : Update event ");
            Console.WriteLine("10 : Remove event ");
            Console.WriteLine("11 : Get event exist");
            Console.WriteLine("12 : Get event date1 between date2");
            Console.WriteLine("13 : Get event Type or Status");
            Console.WriteLine("14 : Delete event Status Closed");
            Console.WriteLine("15 : Update event Status Pending in Open");*/

            ShowMenuContext(channel, userContext, eventContext);

        }

        private static void ShowMenuContext(IService1 channel, UserContext userContext, EventContext eventContext)
        {

            Console.Write(">> ");
            var line = Console.ReadLine();
            switch (line)
            {
                case "1":
                    userContext.ShowUserMenu(channel);
                    break;

                case "2":
                    eventContext.ShowEventMenu(channel);
                    break;

                default:
                    Console.WriteLine("Bad argument");
                    Console.Beep();
                    ShowMenuContext(channel, userContext, eventContext);
                    break;
            }
        }


    }
}





                    /*case "11":
                        Console.Write("Name : ");
                        evenementName = Console.ReadLine();
                        Console.Write("Date : ");
                        var evenementDate = Console.ReadLine();
                        /*getDelete = channel.EventExists(evenementName,evenementDate1);
                        if (getDelete == true)
                            Console.WriteLine("Evènement trouvé.");
                        else
                            Console.WriteLine("Evènement pas trouvé.");#1#
                        break;
                    case "12":
                        Console.Write("Date 1 : ");
                        evenementDate = Console.ReadLine();
                        Console.Write("Date 2 : ");
                        var evenementDate2 = Console.ReadLine();
                        /*events = channel.EventDateRetrieve(evenementDate,evenementDate2);
                        foreach (Event evenementAll in events)
                        {
                            Console.WriteLine("Name Event : " + evenementAll.Name+" adresse : "+evenementAll.Address+" description : "+evenementAll.Description+" date evenement : "+evenementAll.Date.ToString()+" type d'evenement : "+evenementAll.Type+" status : "+evenementAll.Status);
                        }
                            #1#
                        break;
                    case "13":
                        EventType eventUpdateType;
                        Console.Write("Type d'evenement 1:Party, 2:Lunch et 3:Diner : ");
                        var eventUpdateTypeString = Console.ReadLine();
                        if (eventUpdateTypeString == "1")
                            eventUpdateType=EventType.Party;
                        else if (eventUpdateTypeString == "2")
                            eventUpdateType=EventType.Lunch;
                        else if (eventUpdateTypeString == "3")
                            eventUpdateType=EventType.Diner;
                        else{
                            Console.WriteLine("Mauvaise syntaxe pour le type d'evenement 1=Party, 2=Lunch et 3=Diner.");
                            break;
                        }
                        EventStatus eventUpdateStatus;
                        Console.Write("Status d'evenement 1:Open, 2:Pending et 3:Close : ");
                        var eventStatusUpdateString = Console.ReadLine();
                        if (eventStatusUpdateString == "1")
                            eventUpdateStatus = EventStatus.Open;
                        else if (eventStatusUpdateString == "2")
                            eventUpdateStatus = EventStatus.Pending;
                        else if (eventStatusUpdateString == "3")
                            eventUpdateStatus = EventStatus.Closed;
                        else{
                            Console.WriteLine("Mauvaise syntaxe pour le status d'evenement 1=Open, 2=Pending et 3=Closed.");
                            break;
                        }
                        //List<Event> listEventUpdate = channel.EventTypeOrStatusRetrieve(eventUpdateType, eventUpdateStatus);
                        break;
                    case "14":
                        bool getDeleteClosed = channel.EventClosedDelete();
                        if (getDeleteClosed == true)
                            Console.WriteLine("Evènements trouvés et supprimés.");
                        else
                            Console.WriteLine("Aucun évènement trouvé.");
                        break;
                    case "15":
                        bool getDeletePended = channel.EventPendingUpdate();
                        if (getDeletePended == true)
                            Console.WriteLine("Evènements trouvés et changés.");
                        else
                            Console.WriteLine("Evènement pas trouvé.");
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Mauvaise commande.");
                        break;*/