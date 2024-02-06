using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserAPIController()
        {
            userRepository = new UserRepository();
        }
        // GET: api/<UserAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAPIController>/5
        [HttpGet("{username}/{password}")]
        public bool Get(string username, string password)
        {
            var user = userRepository.Login(username, password);
            if (user)
            {
                return true;
            }
            return false;
        }

        // POST api/<UserAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
