using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Partido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PartidoId { get; set; }
        public int GolesEquipo1 { get; set; }
        public int GolesEquipo2 { get; set; }
        public virtual ICollection<Equipo> Equipos { get; set; }

    }
}
