using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PencaController : ControllerBase
    {
        private IBL_Penca _bl;
        private IDAL_Penca _dal;

        public PencaController()
        {
            _dal = new DAL_Penca();
            _bl = new BL_Penca(_dal);
        }

        // GET: api/<PencaController>
        [HttpGet]
        public IEnumerable<Penca> Get()
        {
            return _bl.GetPenca();
        }

        // GET api/<PencaController>/1
        [HttpGet("{id}")]
        public Penca Get(int id)
        {
            return _bl.Get(id);
        }

        // POST api/<PencaController>
        [HttpPost]
        public Penca Post([FromBody] Penca p)
        {
            return _bl.AddPenca(p);
        }

        // PUT api/<PencaController>
        [HttpPut]
        public Penca Put([FromBody] Penca p)
        {
            return _bl.SetPenca(p);
        }

        [HttpPut("SetCampeonato")]
        public Penca SetCampeonato(int idC, int idP) => _bl.AddCampeonato(idC, idP);

        [HttpPut("DeleteCampeonato")]
        public Penca DeleteCampeonato(int idC, int idP) => _bl.DeleteCampeonato(idP);

        [HttpPut("SetUsuario")]
        public User_Penca SetUsuario(string idU, int idP) => _bl.SetUsuarios(idU, idP);

        [HttpPut("DeleteUsuario")]
        public bool DeleteUsuario(string idU, int idP) => _bl.Deleteusuarios(idU, idP);

    }
}
