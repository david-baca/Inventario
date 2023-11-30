using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Accion
    {
        [Key]
        public int PkAccion { get; set; }
        public string Nombre { get; set; }
    }
}