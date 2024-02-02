using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryBookAPIController : ControllerBase
    {
        private readonly ICategoryBookRepository categoryBookRepository;
        public CategoryBookAPIController()
        {
            categoryBookRepository = new CategoryBookRepository();
        }
        // GET: api/<CategoryBookAPIController>
        [HttpGet]
        public IEnumerable<CategoryBook> Get()
        {
            return categoryBookRepository.GetCategories();
        }

        // GET api/<CategoryBookAPIController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryBook> Get(int id)
        {
            var category = categoryBookRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST api/<CategoryBookAPIController>
        [HttpPost]
        public void Post(CategoryBook category)
        {
            categoryBookRepository.InsertCategory(category);
        }

        // PUT api/<CategoryBookAPIController>/5
        [HttpPut("{id}")]
        public void Put(CategoryBook category)
        {
            categoryBookRepository.UpdateCategory(category);
        }

        // DELETE api/<CategoryBookAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryBookRepository.DeleteCategory(id);
        }
    }
}
