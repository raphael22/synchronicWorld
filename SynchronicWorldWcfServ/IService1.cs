using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SynchronicWorldWcfServ
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        ///  Person ////
        [OperationContract]
        Person AddPerson(string name, string nickName);

        [OperationContract]
        Person PersonRetrieve(string name);

        [OperationContract]
        Person PersonUpdate(Person person,string name, string nickname);

        [OperationContract]
        bool PersonDelete(string name);

        [OperationContract]
        List<Person> GetAllPersons();



        ///  Event ////
        [OperationContract]
        Event AddEvent(string name, string address, string description, DateTime date, string time,EventType type,EventStatus status);

        [OperationContract]
        Event EventRetrieve(string name/*, string address, string description, DateTime date, string time, EventType type, EventStatus status*/);

        [OperationContract]
        bool EventUpdate(Event evenement, string name, string address, string description, DateTime date, string time, EventType type, EventStatus status);

        [OperationContract]
        bool EventDelete(string name/*, string address, string description, DateTime date, string time, EventType type, EventStatus status*/);

        [OperationContract]
        bool EventExists(string name, DateTime date);

        [OperationContract]
        List<Event> EventDateRetrieve(DateTime date1, DateTime date2);

        [OperationContract]
        List<Event> EventTypeOrStatusRetrieve( EventType type, EventStatus status);

        [OperationContract]
        bool EventClosedDelete();

        [OperationContract]
        bool EventPendingUpdate();

        [OperationContract]
        List<Event> GetAllEvents();
        ///  Contribution ////

        [OperationContract]
        Contribution AddContribution(string name, int quantity, ContributionType type);

        [OperationContract]
        List<Contribution> GetAllContributions();

    }
}
