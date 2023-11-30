using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class FuenteResponse
    {
        public int IdUsuario { get; set; }
        public int Pk { get; set; }
        public string Nombre { get; set; }

        public FuenteResponse Conversor(Fuente i)
        {
            FuenteResponse request = new FuenteResponse()
            {
                Nombre = i.Nombre,
                Pk = i.PkFuente
            };

            return request;
        }

        public List<FuenteResponse> ListConvert(List<Fuente> i)
        {
            List<FuenteResponse> request = new List<FuenteResponse>();

            foreach (Fuente item in i)
            {
                FuenteResponse response = new FuenteResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Fuente Inversor(FuenteResponse i)
        {
            Fuente request = new Fuente()
            {
                Nombre = i.Nombre,
                Estado = true
            };

            return request;
        }

        public List<Fuente> ListInversor(List<FuenteResponse> i)
        {
            List<Fuente> request = new List<Fuente>();

            foreach (FuenteResponse item in i)
            {
                FuenteResponse response = new FuenteResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }

    }

   
}
