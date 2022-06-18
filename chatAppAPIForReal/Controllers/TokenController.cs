using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chatAppAPIForReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // user id to firebase token
        public static Dictionary<string, string> IdToFirebase = new Dictionary<string, string>();
        // GET: api/<TokenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TokenController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TokenController>
        [HttpPost]
        public void Post([FromBody] Token value)
        {
            if (value == null) return;
            IdToFirebase[value.UserId] = value.FirebaseToken;
        }

        // PUT api/<TokenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TokenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
