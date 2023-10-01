using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Responsable
    {
        [Key]
        public int PkResponsable { get; set; }

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        [ForeignKey("Rol")]

        public int FkRol { get; set; }

        public Rol Rol { get; set; }

        public bool Estado { get; set; }
    }
}
