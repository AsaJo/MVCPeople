using MVCPeople.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.Repos
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> peopleList = new List<Person>();
        private static int idCounter = 0;
        public Person CreatePerson(string name, string phonenumber, string city)
        {
            Person person = new Person(name, phonenumber, city);

            person.PersonId = ++idCounter;
            person.Name = name;
            person.PhoneNumber = phonenumber;
            person.City = city;
            peopleList.Add(person);
            return person;
        }

        public bool Delete(Person person)
        {

            return peopleList.Remove(person);
        }

        public List<Person> Read()
        {
            return peopleList;
        }

        public Person Read(int id)
        {
            foreach (Person person in peopleList)
            {
                if (person.PersonId == id)
                {
                    return person;

                }
            }
            return null;
        }

        public bool Update(Person person)
        {
            Person per = Read(person.PersonId);
            if (per != null)
            {
                per.Name = person.Name;
                per.City = person.City;
                per.PhoneNumber = person.PhoneNumber;
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
