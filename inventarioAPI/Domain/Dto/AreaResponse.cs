using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class AreaResponse
    {
        public int Pk { get; set; } 
        public string Nombre { get; set; }

        public AreaResponse Conversor(Area i)
        {
            AreaResponse request = new AreaResponse()
            {
                Nombre = i.Nombre,
                Pk = i.PkArea
            };

            return request;
        }

        public List<AreaResponse> ListConvert(List<Area> i)
        {
            List<AreaResponse> request = new List<AreaResponse>();

            foreach (Area item in i)
            {
                AreaResponse response = new AreaResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }


        public Area Inversor(AreaResponse i)
        {
            Area request = new Area()
            {
                Nombre = i.Nombre,
                Estado = true
            };

            return request;
        }

        public List<Area> ListInversor(List<AreaResponse> i)
        {
            List<Area> request = new List<Area>();

            foreach (AreaResponse item in i)
            {
                AreaResponse response = new AreaResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }

    }

   
}
