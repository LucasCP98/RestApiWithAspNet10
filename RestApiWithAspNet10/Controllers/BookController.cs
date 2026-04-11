using Microsoft.AspNetCore.Mvc;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;
using RestApiWithAspNet10.Service;

namespace RestApiWithAspNet10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookServices bookServices, ILogger<BookController> logger)
        {
            _bookServices = bookServices;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all books");
            return Ok(_bookServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation($"Fetching book with ID: {id}");
            var book = _bookServices.FindById(id);
            if (book == null) 
            { 
                _logger.LogWarning($"Book with ID {id} not found");
                return NotFound(); 
            }
            return Ok(book);
        }

        [HttpPost]
        // FromBody diz que o objeto person vem do corpo da requisição (JSON)
        // usado para cadastrar uma pessoa e o mais recomendado é o FromBody.
        public IActionResult Post([FromBody] BookDTO book) 
        {
            _logger.LogInformation($"Create new Book: {book.Title}");
            var createdBook = _bookServices.Create(book);
            if (createdBook == null) 
            { 
                _logger.LogError($"Failed to create book with name {book.Title}");
                return NotFound(); 
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDTO book)
        {
            _logger.LogInformation($"Updating book with ID: {book.Id}");
            var updateBook = _bookServices.Update(book);
            if (updateBook == null) 
            { 
                _logger.LogError($"Failed to upadate Book with ID: {book.Id}");
                return NotFound();
            }
            _logger.LogDebug($"Book updated successfully: {book.Title}");
            return Ok(updateBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookServices.FindById(id);

            if (book == null)
            {
                _logger.LogError($"Failed to Delete Book with ID: {id} not exist.");
                return NotFound();
            }
                
            _logger.LogInformation($"Deleting book with ID: {id} deleted successfully");
            _bookServices.Delete(id);
            return NoContent();
        }
    }
}    