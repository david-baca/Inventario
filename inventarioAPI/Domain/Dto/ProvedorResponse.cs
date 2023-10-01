using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ProvedorResponse
    {
        public int Pk { get; set; }
        public string Nombre { get; set; }

        public ProvedorResponse Conversor(Provedor i)
        {
            ProvedorResponse request = new ProvedorResponse()
            {
                Nombre = i.Nombre,
                Pk = i.PkProvedor
            };

            return request;
        }

        public List<ProvedorResponse> ListConvert(List<Provedor> i)
        {
            List<ProvedorResponse> request = new List<ProvedorResponse>();

            foreach (Provedor item in i)
            {
                ProvedorResponse response = new ProvedorResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Provedor Inversor(ProvedorResponse i)
        {
            Provedor request = new Provedor()
            {
                Nombre = i.Nombre,
                Estado = true
            };

            return request;
        }

        public List<Provedor> ListInversor(List<ProvedorResponse> i)
        {
            List<Provedor> request = new List<Provedor>();

            foreach (ProvedorResponse item in i)
            {
                ProvedorResponse response = new ProvedorResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }
    }

   
}
