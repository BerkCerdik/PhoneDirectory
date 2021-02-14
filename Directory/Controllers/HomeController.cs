using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Directory.Model.ORM.Context;
using Directory.Model.ORM.Entities;
using Directory.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Directory.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DirectoryContext _directorycontext;

        public HomeController(DirectoryContext directorycontext)
        {
            _directorycontext = directorycontext;
        }



        [Route("anasayfa")]
        [HttpGet]
        public List<DirectoryListVM> Index()
        {

            var people = _directorycontext.People.Where(c => c.IsDeleted == false).Select(q => new DirectoryListVM()
            {
                PersonID = q.ID,
                PersonName = q.Name,
                PersonSurname = q.Surname,
                Company = q.Company,
                ContactInfoList = q.ContactInformation.Where(q => q.IsDeleted == false).ToList()

            }).ToList();

            return people;
        }

        [Route("kisiler")]
        [HttpGet]
        public List<DirectoryListVM> People()
        {

            var people = _directorycontext.People.Where(c => c.IsDeleted == false).Select(q => new DirectoryListVM()
            {
                PersonID = q.ID,
                PersonName = q.Name,
                PersonSurname = q.Surname,
                Company = q.Company
            }).ToList();

            return people;
        }


        [Route("kisilist/{id}")]
        [HttpGet]
        public PeopleListVM PeopleListDetail(int id)
        {
            var people = _directorycontext.People.FirstOrDefault(c => c.ID == id && c.IsDeleted == false);

            if (people != null)
            {
                var peopleList = _directorycontext.People.Where(q => q.IsDeleted == false).Select(q => new PeopleListVM()
                {
                    PeopleID = q.ID,
                    PeopleName = q.Name,
                    PeopleSurname = q.Surname,
                    PeopleCompany = q.Company,
                    IsDeleted = q.IsDeleted,
                    ContactInfoList = q.ContactInformation.Where(q => q.IsDeleted == false).ToList()
                }).FirstOrDefault(q => q.PeopleID == id);

                return peopleList;
            }
            else
            {
                return null;
            }
        }

        [Route("kisiekle")]
        [HttpPost]
        public IActionResult PeopleAdd([FromForm] PersonVM personVM)
        {
            Person person = new Person();
            if (ModelState.IsValid)
            {
                person.Name = personVM.Name;
                person.Surname = personVM.Surname;
                person.Company = personVM.Company;

                _directorycontext.People.Add(person);
                _directorycontext.SaveChanges();

                return Ok(personVM);
            }
            else
            {
                return BadRequest(ModelState.IsValid);
            }
        }

        [Route("kisisil")]
        [HttpPost]
        public IActionResult PeaopleDelete([FromForm] PersonDeleteVM personDelete)
        {

            Person person = _directorycontext.People.Find(personDelete.ID);

            if (person != null)
            {
                person.IsDeleted = true;
                _directorycontext.SaveChanges();

                return Ok(person);
            }
            else
            {
                return BadRequest("There is no ID you are looking for!!!");
            }

        }

        [Route("iletisimekle")]
        [HttpPost]
        public IActionResult ContactAdd([FromForm] ContactInfoVM contactInfo)
        {

            if (ModelState.IsValid)
            {
                ContactInformation contact = new ContactInformation();

                contact.PersonID = contactInfo.PersonID;
                contact.Phone = contactInfo.Phone;
                contact.EMail = contactInfo.EMail;
                contact.Location = contactInfo.Location;
                contact.InformationContent = contactInfo.InformationContent;

                _directorycontext.ContactInformation.Add(contact);
                _directorycontext.SaveChanges();

                return Ok(contact);

            }
            else
            {
                return BadRequest("There is no ID you are looking for!!!");
            }
        }

        [Route("iletisimsil")]
        [HttpPost]
        public IActionResult ContactDelete([FromForm] ContactDeleteVM contactDelete)
        {

            ContactInformation contactInformation  = _directorycontext.ContactInformation.Find(contactDelete.ID);

            if (contactInformation != null)
            {
                contactInformation.IsDeleted = true;
                _directorycontext.SaveChanges();

                return Ok(contactInformation);

            }
            else
            {
                return BadRequest("There is no ID you are looking for!!!");
            }
        }

    }
}
