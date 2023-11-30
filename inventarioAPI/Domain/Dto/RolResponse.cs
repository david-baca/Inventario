using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Dto
{

    public class RolResponse
    {
        public int IdUsuario { get; set; }
        public int Pk { get; set; }
        public string Nombre { get; set; }

        public RolResponse Conversor(Rol i)
        {
            RolResponse request = new RolResponse()
            {
                Nombre = i.Nombre,
                Pk = i.PkRol
            };

            return request;
        }

        public List<RolResponse> ListConvert(List<Rol> i)
        {
            List<RolResponse> request = new List<RolResponse>();

            foreach (Rol item in i)
            {
                RolResponse response = new RolResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Rol Inversor(RolResponse i)
        {
            Rol request = new Rol()
            {
                Nombre = i.Nombre,
                Estado = true
            };

            return request;
        }

        public List<Rol> ListInversor(List<RolResponse> i)
        {
            List<Rol> request = new List<Rol>();

            foreach (RolResponse item in i)
            {
                RolResponse response = new RolResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }
    }

   

}
