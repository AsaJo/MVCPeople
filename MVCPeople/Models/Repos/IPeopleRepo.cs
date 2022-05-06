using MVCPeople.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.Repos
{
    public interface IPeopleRepo
    {
        public Person CreatePerson(string name, string phonenumber, string city);
        public List<Person> Read();
        public Person Read(int id);
        public bool Update(Person person);
        public bool Delete(Person person);
    }
}
