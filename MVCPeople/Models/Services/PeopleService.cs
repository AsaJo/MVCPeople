using MVCPeople.Models.Repos;
using MVCPeople.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo PeopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            PeopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel person)
        {

            Person newperson = PeopleRepo.CreatePerson(person.Name, person.PhoneNumber, person.City);
            if (string.IsNullOrWhiteSpace(person.Name)
                || string.IsNullOrWhiteSpace(person.PhoneNumber)
                || string.IsNullOrWhiteSpace(person.City))
            {
                throw new ArgumentException("Name,Phonenuber or City can not be null.");
            }

            return newperson;
        }

        public List<Person> All()
        {
            return PeopleRepo.Read();
        }

        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
            Person person = PeopleRepo.Read(id);
            if
             (editPerson.Name == person.Name ||
             editPerson.PhoneNumber == person.PhoneNumber ||
             editPerson.City == person.City)
            {
                return true;
            }
            else
                return false;
        }

        public Person FindById(int id)
        {
            return PeopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Person DeletedPerson = PeopleRepo.Read(id);
            return PeopleRepo.Delete(DeletedPerson);
        }

        public List<Person> Search(string search)
        {
            List<Person> PersonList = PeopleRepo.Read();
            //
            foreach (Person per in PersonList)
            {
                if (per.Name.Contains(search) || per.City.Contains(search))
                {
                    PersonList.Add(per);
                }
            }

            if (PersonList.Count == 0)
            {
                throw new ArgumentException(" Sorry! Could not finde what you searched!");
            }
            return PersonList;
        }
    }
}
