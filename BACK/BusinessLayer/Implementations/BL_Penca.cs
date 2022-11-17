using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Shared;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BL_Penca : IBL_Penca
    {
        private IDAL_Penca _penca;

        public BL_Penca(IDAL_Penca penca)
        {
            _penca = penca;
        }

        public List<Penca> GetPenca()
        {
            return _penca.GetPenca();
        }

        public Penca Get(int id)
        {
            return _penca.Get(id);
        }

        public Penca AddPenca(Penca penca)
        {
            return _penca.AddPenca(penca);
        }

        public Penca SetPenca(Penca penca)
        {
            return _penca.SetPenca(penca);
        }

        public Penca AddCampeonato(int c, int p)
        {
            return _penca.AddCampeonato(c, p);
        }

        public Penca DeleteCampeonato(int p)
        {
            return _penca.DeleteCampeonato(p);
        }

        public User_Penca SetUsuarios(string u, int p)
        {
            return _penca.SetUsuarios(u, p);
        }

        public bool Deleteusuarios(string u, int p)
        {
            return _penca.Deleteusuarios(u, p);
        }
    }
}
