using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public static List<Person> People = new List<Person>();

        public PeopleController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return People.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            return People.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Person person)
        {
            People.Add(person);
            return Ok();
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}