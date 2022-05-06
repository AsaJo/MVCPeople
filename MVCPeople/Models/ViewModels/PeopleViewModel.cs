using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> PersonList { get; set; }
        public string Filter { get; set; }
    }
}
