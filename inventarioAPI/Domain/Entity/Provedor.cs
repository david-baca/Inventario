using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Provedor
    {
        [Key]
        public int PkProvedor { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}
