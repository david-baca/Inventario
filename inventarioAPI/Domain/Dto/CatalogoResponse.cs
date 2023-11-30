using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CatalogoResponse
    {
        public int IdUsuario { get; set; }
        public int Pk { get; set; }
        public string Nombre { get; set; }

      

        public CatalogoResponse Conversor(Catalogo i)
        {
            CatalogoResponse request = new CatalogoResponse()
            {
                Nombre = i.Nombre,
                Pk = i.PkCatalogo
            };

            return request;
        }

        public List<CatalogoResponse> ListConvert(List<Catalogo> i)
        {
            List<CatalogoResponse> request = new List<CatalogoResponse>();

            foreach (Catalogo item in i)
            {
                CatalogoResponse response = new CatalogoResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Catalogo Inversor(CatalogoResponse i)
        {
            Catalogo request = new Catalogo()
            {
                Nombre = i.Nombre,
                Estado = true
            };

            return request;
        }

        public List<Catalogo> ListInversor(List<CatalogoResponse> i)
        {
            List<Catalogo> request = new List<Catalogo>();

            foreach (CatalogoResponse item in i)
            {
                CatalogoResponse response = new CatalogoResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }
    }

   
   
}
