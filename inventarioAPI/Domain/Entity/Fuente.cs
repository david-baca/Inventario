using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Fuente
    {
        [Key]
        public int PkFuente { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}
