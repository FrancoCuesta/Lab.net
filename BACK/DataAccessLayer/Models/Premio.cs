using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Premio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [MaxLength(128), MinLength(3), Required]

        public string descripcion { get; set; }

        [MinLength(1), Required ]

        public float monto { get; set; }
        public bool estado { get; set; }

        public Shared.Premio ToEntity()
        {
            return new Shared.Premio()
            {
                id = id,
                descripcion = descripcion,
                monto = monto
            };
        }

        public static Premio ToSave(Shared.Premio x)
        {
            return new Premio()
            {
                id = x.id,
                descripcion = x.descripcion,
                monto = x.monto
            };
        }

    }
}
