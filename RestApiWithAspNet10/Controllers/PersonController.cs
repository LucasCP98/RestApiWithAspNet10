using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiWithAspNet10.Controllers.Model;
using RestApiWithAspNet10.Controllers.Service;

namespace RestApiWithAspNet10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices)
        {
            _personServices = personServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personServices.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        // FromBody diz que o objeto person vem do corpo da requisição (JSON)
        // usado para cadastrar uma pessoa e o mais recomendado é o FromBody.
        public IActionResult Post([FromBody] Person person) 
        {
            var createdPerson = _personServices.Create(person);
            if (createdPerson == null) return NotFound();
            return Ok(_personServices.Create(createdPerson));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var updatePerson = _personServices.Update(person);
            if (updatePerson == null) return NotFound();
            return Ok(_personServices.Update(updatePerson));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personServices.Delete(id);
            return NoContent();
        }
    }
}    