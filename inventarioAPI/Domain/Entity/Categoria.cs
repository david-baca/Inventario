using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Categoria
    {
        [Key]
        public int PkCategoria { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion{ get; set; }


        [ForeignKey("Catalogo")]

        public int FkCatalogo { get; set; }

        public Catalogo Catalogo { get; set; }

        public bool Estado { get; set; }

      

    }
}
