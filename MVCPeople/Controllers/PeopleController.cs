using Microsoft.AspNetCore.Mvc;
using MVCPeople.Models;
using MVCPeople.Models.Repos;
using MVCPeople.Models.Services;
using MVCPeople.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        public PeopleController()
        {
            _peopleService = new PeopleService(new InMemoryPeopleRepo());
        }

        public IActionResult People()
        {
            return View(_peopleService.All());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }
        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Add(createPerson);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name,Phonenumber & City", exception.Message);
                    return View(createPerson);
                }

                return RedirectToAction(nameof(People));
            }
            return View(createPerson);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }

            return View(person);
        }

        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);
            //_peopleService.Remove(id);
            if (person == null)
            {
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }
            else
            {
                _peopleService.Remove(id);

            }

            return View();
        }
        [HttpPost]
        public IActionResult People(string search)
        {
            if (search != null)
            {
                return View(_peopleService.Search(search));
            }
            return RedirectToAction(nameof(People));
        }

    }
}
