using Microsoft.AspNetCore.Mvc;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Service;

namespace RestApiWithAspNet10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PersonDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all persons");
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation($"Fetching person with ID: {id}");
            var person = _personServices.FindById(id);
            if (person == null) 
            { 
                _logger.LogWarning($"Person with ID {id} not found");
                return NotFound(); 
            }
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] PersonDTO person) 
        {
            _logger.LogInformation($"Create new Person: {person.FirstName}");
            var createdPerson = _personServices.Create(person);
            if (createdPerson == null) 
            { 
                _logger.LogError($"Failed to create person with name {person.FirstName}");
                return NotFound(); 
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation($"Updating person with ID: {person.Id}");
            var updatePerson = _personServices.Update(person);
            if (updatePerson == null) 
            { 
                _logger.LogError($"Failed to upadate Person with ID: {person.Id}");
                return NotFound();
            }
            _logger.LogDebug($"Person updated successfully: {person.FirstName}");
            return Ok(updatePerson);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            var person = _personServices.FindById(id);

            if (person == null)
            {
                _logger.LogError($"Failed to Delete Person with ID: {id} not exist.");
                return NotFound();
            }
                
            _logger.LogInformation($"Deleting person with ID: {id} deleted successfully");
            _personServices.Delete(id);
            return NoContent();
        }
    }
}    