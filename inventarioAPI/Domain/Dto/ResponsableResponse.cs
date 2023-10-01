using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ResponsableResponse
    {
        public int Pk { get; set; }
        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public int FkRol { get; set; }


        public ResponsableResponse Conversor(Responsable i)
        {
            ResponsableResponse request = new ResponsableResponse()
            {
              Pk = i.PkResponsable,
              Nombre = i.Nombre,
              ApellidoP = i.ApellidoP,
              ApellidoM = i.ApellidoM,
              FkRol = i.FkRol,
            };

            return request;
        }

        public List<ResponsableResponse> ListConvert(List<Responsable> i)
        {
            List<ResponsableResponse> request = new List<ResponsableResponse>();

            foreach (Responsable item in i)
            {
                ResponsableResponse response = new ResponsableResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Responsable Inversor(ResponsableResponse i)
        {
            Responsable request = new Responsable()
            {
              
                Nombre = i.Nombre,
                ApellidoP = i.ApellidoP,
                ApellidoM = i.ApellidoM,
                FkRol = i.FkRol,
                Estado = true

            };

            return request;
        }

        public List<Responsable> ListInversor(List<ResponsableResponse> i)
        {
            List<Responsable> request = new List<Responsable>();

            foreach (ResponsableResponse item in i)
            {
                ResponsableResponse response = new ResponsableResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }

    }

}

