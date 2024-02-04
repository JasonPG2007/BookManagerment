using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        public BookAPIController()
        {
            bookRepository = new BookRepository();
        }
        // GET: api/<BookAPIController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var list = bookRepository.GetBooks();
            return list;
        }

        // GET api/<BookAPIController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var check = bookRepository.GetBookById(id);
            if (check != null)
            {
                return check;
            }
            return NotFound();
        }

        // POST api/<BookAPIController>
        [HttpPost]
        public void Post(Book book)
        {
            bookRepository.InsertBook(book);
        }

        // PUT api/<BookAPIController>/5
        [HttpPut("{id}")]
        public void Put(Book book)
        {
            bookRepository.UpdateBook(book);
        }

        // DELETE api/<BookAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookRepository.DeleteBook(id);
        }
    }
}
