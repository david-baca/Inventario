using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Catalogo
    {
        [Key]
        public int PkCatalogo { get; set; }
        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}
