using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Directory.Model.ORM.Context;
using Directory.Model.ORM.Entities;
using Directory.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            List<Person> people = _directorycontext.People.Where(a => a.IsDeleted == false).ToList();
            return Ok(people);
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

            Person person= _directorycontext.People.Find(personDelete.ID);

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
    }
}
