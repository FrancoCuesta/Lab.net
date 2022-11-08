using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "USER")]

    public class PrediccionController : ControllerBase
    {
        // GET: api/<PrediccionController>
        [HttpGet]
        public IEnumerable<Prediccion> Get()
        {
            return null;
        }

        // GET api/<PrediccionController>/45293204
        [HttpGet("{id}")]
        public Prediccion Get(string id)
        {
            return null;
        }

        // POST api/<PrediccionController>
        [HttpPost]
        public Prediccion Post([FromBody] Prediccion value)
        {
            return null;
        }

        // PUT api/<PrediccionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrediccionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}