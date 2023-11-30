using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Domain.Dto
{
    public class HistorialResponse
    {
        public int PkHistorial { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }
        public UsuarioResponse Usuario {  get; set; }
        public string Accion { get; set; }

        public HistorialResponse Conversor(Historial i)
        {
            UsuarioResponse x = new UsuarioResponse();
            HistorialResponse request = new HistorialResponse()
            {
                PkHistorial = i.PkHistorial,
                Descripcion = i.Descripcion,
                Fecha = i.Fecha,
                Usuario = x.Conversor(i.Usuario),
                Accion = i.Accion.Nombre
            };

            return request;
        }

        public List<HistorialResponse> ListConvert(List<Historial> i)
        {
            List<HistorialResponse> request = new List<HistorialResponse>();

            foreach (Historial item in i)
            {
                HistorialResponse response = new HistorialResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }
    }
}
