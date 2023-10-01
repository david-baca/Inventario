using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }

        public string Nombres { get; set; }
        public string Apellido_P { get; set; }
        public string Apellido_M { get; set; }
        public string Contrseña { get; set; }
        public string N_Usuario { get; set; }

        [ForeignKey("Rol")]

        public int FkRol { get; set; }

        public Rol Rol { get; set; }

        public bool Estado { get; set; }
    }
}
