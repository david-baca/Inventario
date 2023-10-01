using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Area
    {
        [Key]

        public int PkArea { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}
