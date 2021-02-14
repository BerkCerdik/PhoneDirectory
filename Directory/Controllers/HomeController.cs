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
        public List<DirectoryListVM> Index()
        {

            var people = _directorycontext.People.Where(c => c.IsDeleted == false).Select(q => new DirectoryListVM()
            {
                PersonID = q.ID,
                PersonName = q.Name,
                PersonSurname = q.Surname,
                Company = q.Company,
                ContactInfoList = q.ContactInformation
                //ContactInfoList = _directorycontext.ContactInformation.ToList()
                //ContactInfoList = _directorycontext.ContactInformation.Include(b => b.Person).Where(a => a.PersonID == a.Person.ID).ToList()

            }).ToList();

            //List<ContactInformation> contact= _directorycontext.ContactInformation.Include(b => b.Person).Where(a => a.PersonID == a.Person.ID).ToList();

            return people;
        }





        [Route("kisilist/{id}")]
        public IActionResult PeopleList(int id)
        //public List<PeopleListVM> PeopleList(int id)
        {
            var people = _directorycontext.People.Where(c => c.IsDeleted == false).FirstOrDefault(c => c.ID == id);
            PeopleListVM peopleList = new PeopleListVM();

            if (people != null)
            {
                peopleList.PeopleID = people.ID;
                peopleList.PeopleName = people.Name;
                peopleList.PeopleSurname = people.Surname;
                peopleList.PeopleCompany = people.Company;

                return Ok(peopleList);
            }
            else
            {
                return BadRequest("There is no ID you are looking for!!!");
            }
        }



        [Route("kisiekle")]
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

        [Route("contactekle")]
        public IActionResult ContactAdd([FromForm] ContactInfoVM contactInfo)
        {

            //Person person = _directorycontext.People.FirstOrDefault(a =>a.ID == contactInfo.PersonID);


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
    }
}
