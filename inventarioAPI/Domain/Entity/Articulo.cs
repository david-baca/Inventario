using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Articulo
    {

        [Key]
        public int PkArticulo { get; set; }

        public DateTime FEQADD { get; set; }

        public DateTime FEQ_ASC { get; set; }

        public int Costo { get; set; }

        public string Polisa { get; set; }

        public string Factura { get; set; }

        public string Token { get; set; }


        [ForeignKey("Categoria")]

        public int FkCategoria { get; set; }

        public Categoria Categoria { get; set; }


        [ForeignKey("Provedor")]

        public int FkProvedor { get; set; }

        public Provedor Provedor { get; set; }


        [ForeignKey("Fuente")]

        public int FkFuente { get; set; }

        public Fuente Fuente { get; set; }

        [ForeignKey("Area")]

        public int FkArea { get; set; }

        public Area Area { get; set; }

        [ForeignKey("Responsable")]

        public int FkResponsable { get; set; }

        public Responsable Responsable { get; set; }


        public bool Estado_Articulo { get; set; }

        public bool Estado { get; set; }

    }
}
