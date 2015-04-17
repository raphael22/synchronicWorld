using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SynchronicWorldConsole.ServiceReference1;

namespace SynchronicWorldConsole
{
    public class UserContext
    {
        public void ShowUserMenu(IService1 channel)
        {
            Console.Clear();
            Console.WriteLine("****** SyncronicWorld ******");
            Console.WriteLine("");
            Console.WriteLine("> User Menu");
            Console.WriteLine("1 : Create User");
            Console.WriteLine("2 : Retrieve All Users");
            Console.WriteLine("3 : Retrieve User");
            Console.WriteLine("4 : Update User");
            Console.WriteLine("5 : Delete User");
            Console.WriteLine("");

            ShowUserMenuAction(channel);
        }

        public void ShowUserMenuAction(IService1 channel)
        {
            Console.WriteLine("");
            Console.Write(">> ");
            var line = Console.ReadLine();
            Console.WriteLine("");

            switch (line)
            {
                case "1":
                    CreatePerson(channel);
                    break;
                case "2":
                    ShowAllPersons(channel);
                    break;
                case "3":
                    GetPerson(channel);
                    break;
                case "4":
                    DeletePerson(channel);
                    break;
                case "5":
                    UpdatePerson(channel);
                    break;
                default:
                    Console.WriteLine("Bad argument");
                    break;
            }
        }

        public void ShowAllPersons(IService1 channel)
        {
            var persons = channel.GetAllPersons();
            foreach (Person person in persons)
            {
                Console.WriteLine("Id " + person.Id + " - Name : " + person.Name + " Nickname : " + person.NickName);
            }
            ShowUserMenuAction(channel);
        }

        public void CreatePerson(IService1 channel)
        {
            Console.Write("Name : ");
            var name = Console.ReadLine();
            Console.Write("Nickname : ");
            var nickname = Console.ReadLine();

            var user = channel.AddPerson(name, nickname);
            if (user!=null)
                Console.WriteLine("User create !");
            else
                Console.WriteLine("User fail to create...");

            ShowUserMenuAction(channel);
        }

        public void DeletePerson(IService1 channel)
        {
            Console.Write("Name : ");
            var nameDelete = Console.ReadLine();
            Console.Write("Nickname : ");
            var nicknameDelete = Console.ReadLine();

            bool getDelete = channel.PersonDelete(nicknameDelete, nicknameDelete);
            if (getDelete == true)
                Console.WriteLine("Utilisateur trouvé et supprimé.");
            else
                Console.WriteLine("Utilisateur pas trouvé.");

            
            ShowUserMenuAction(channel);
        }

        public void UpdatePerson(IService1 channel)
        {
            Console.Write("Name : ");
            var nameOldUpdate = Console.ReadLine();
            Console.Write("Nickname : ");
            var nicknameOldUpdate = Console.ReadLine();
            Person personUpdate = channel.PersonRetrieve(nameOldUpdate, nicknameOldUpdate);

            if (personUpdate == null)
            {
                Console.WriteLine("Utilisateur trouvé.");
                Console.Write("Name update : ");
                var nameUpdate = Console.ReadLine();

                Console.Write("Nickname update : ");
                var nicknameUpdate = Console.ReadLine();

                channel.PersonUpdate(personUpdate, nameUpdate, nicknameUpdate);
                Console.WriteLine("Utilisateur changé.");
            }
            else
                Console.WriteLine("Utilisateur pas trouvé.");


            ShowUserMenuAction(channel);
        }

        public void GetPerson(IService1 channel)
        {
            Console.Write("Name : ");
            var getName = Console.ReadLine();
            Console.Write("Nickname : ");
            var getNickname = Console.ReadLine();
            Person getRetrieve = channel.PersonRetrieve(getName, getNickname);
            if (getRetrieve == null)
                Console.WriteLine("Utilisateur trouvé.");
            else
                Console.WriteLine("Utilisateur pas trouvé.");


            ShowUserMenuAction(channel);
        }
    }
}
