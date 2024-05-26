using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_App.Interfaces;
using Web_App.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;
        public PersonController(IPersonServices personServices) { 
            _personServices = personServices;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var persons = _personServices.GetPersonDetails();
            return persons;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            var person = _personServices.GetPerson(id);
            return person;
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                _personServices.AddPerson(person);
                return StatusCode(StatusCodes.Status201Created, person);
            }
            catch (Exception){
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public Person Put(int id, [FromBody] Person value)
        {
            var person = _personServices.UpdatePerson(value);
            return person;
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var isDeleted = _personServices.DeletePerson(id);
            if (isDeleted)
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
    }
}
