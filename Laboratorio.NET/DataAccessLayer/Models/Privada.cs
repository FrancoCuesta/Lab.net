using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Privada : Penca
    {
        public Double costoEntrada;
        public int cantidadGanadores;
    }
}
