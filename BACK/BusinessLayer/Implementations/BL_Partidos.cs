using BusinessLayer.Interfaces;
using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BL_Partidos : IBL_Partidos
    {
        private IDAL_Partidos _partidos;

        public BL_Partidos(IDAL_Partidos partidos)
        {
            _partidos = partidos;
        }

        public List<Partido> GetPartidos()
        {
            return _partidos.GetPartidos();
        }

        public Partido GetPartido(int id)
        {
            return _partidos.Get(id);
        }

        public Partido AddPartido(Partido partido)
        {
            return _partidos.AddPartido(partido);
        }

        public Partido SetPartido(Partido partido)
        {
            return _partidos.SetPartido(partido);
        }

        public Partido CargarResultado(int id, int golA, int golB)
        {
            return _partidos.CargarResultado(id, golA, golB);
        }
    }
}
