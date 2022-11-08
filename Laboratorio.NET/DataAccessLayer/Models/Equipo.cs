using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Equipo{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Escudo { get; set; }
    }
}
