using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Prediccion{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PrediccionId { get; set; }
        public int GolesEquipo1 { get; set; }
        public int GolesEquipo2 { get; set; }
        public Double Puntos { get; set; }
        [ForeignKey("Personas")]
        public virtual string UsuarioId { get; set; }
        public virtual Users Usuario { get; set; }
        [ForeignKey("Partido")]
        public virtual int PartidoId { get; set; }
        public virtual Partido Partido { get; set; }/*
        [ForeignKey("Penca")]
        public virtual int PencaId { get; set; }
        public virtual Penca Penca { get; set; }*/
    }
    }
