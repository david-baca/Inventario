using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Historial
    {
        [Key]
        public int PkHistorial { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }


        [ForeignKey("Usuario")]

        public int FkUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [ForeignKey("Accion")]

        public int FkAccion { get; set; }

        public Accion Accion { get; set; }
    }
}
