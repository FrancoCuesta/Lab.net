using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "USER")]

    public class ResultadoController : ControllerBase
    {
        // GET: api/<ResultadoController>
        [HttpGet]
        public IEnumerable<Resultado> Get()
        {
            return null;
        }

        // GET api/<ResultadoController>/45293204
        [HttpGet("{id}")]
        public Resultado Get(string id)
        {
            return null;
        }

        // POST api/<ResultadoController>
        [HttpPost]
        public Resultado Post([FromBody] Resultado value)
        {
            return null;
        }

        // PUT api/<ResultadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ResultadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}