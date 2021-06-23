using StandardClassLibrary;
using StandardClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrameworkWeb.Controllers
{
    public class PersonController : ApiController
    {
        PersonService service;

        public PersonController()
        {
            service = new PersonService();
        }


        // GET: api/Person
        public IEnumerable<Person> GetAll()
        {
            return service.People(5);
        }

        // GET: api/Person/5
        [HttpGet]
        public Person Get(int id)
        {
            return service.People(id + 1).FirstOrDefault(p => p.Id == id);
        }

        [HttpGet]
        public string GetPersonAsString(int id)
        {
            return service.GetPersonAsJson(id);
        }

        // POST: api/Person
        public void Post([FromBody]Person person)
        {

        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]Person person)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {

        }


    }
}
