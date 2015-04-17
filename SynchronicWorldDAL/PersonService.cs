using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldDAL
{
    public class PersonService
    {

        private static SynchronicWorldContext swc = new SynchronicWorldContext();

        public Person addPerson(Person person)
        {
            swc.Persons.Add(person);
            swc.SaveChanges();
            return person;
        }

        public bool removePerson(Person person){
            swc.Persons.Remove(swc.Persons.Find(person.Id));
            swc.SaveChanges();
            return true;
        }

        public Person getPersonName(string name){
                //Person person = context.Persons.Find();
            Person person = swc.Persons.FirstOrDefault();
            
            return person;
        }

        public List<Person> getAllPerson(){
            var persons = from p in swc.Persons select p;
            return persons.ToList();
        }

        public Person updatePerson(Person person)
        {
            swc.Entry(person).State = EntityState.Modified;
            swc.SaveChanges();
            return person;
        }

        public Person getPerson(string name)
        {
            Person person = (from p in swc.Persons where p.Name == name select p).FirstOrDefault();
            //var person = swc.Persons.Where()    
            return person;
        }
    }
}
