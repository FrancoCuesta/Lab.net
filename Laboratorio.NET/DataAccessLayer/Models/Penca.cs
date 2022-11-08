using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Penca
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PencaId { get; set; }

        [ForeignKey("Campeonato")]
        public virtual int CampeonatoId { get; set; }
        public virtual Campeonato Campeonato { get; set; }
    }
}
