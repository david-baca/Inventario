using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class UsuarioResponse
    {

        public int Pk { get; set; }
        public string Nombres { get; set; }
        public string Apellido_P { get; set; }
        public string Apellido_M { get; set; }
        public string Contrseña { get; set; }
        public string N_Usuario { get; set; }

        public int Fk { get; set; }

        public UsuarioResponse Conversor(Usuario i)
        {
            UsuarioResponse request = new UsuarioResponse()
            {
                Pk = i.PkUsuario,
                Nombres = i.Nombres,
                Apellido_P = i.Apellido_P,
                Apellido_M = i.Apellido_M,
                Contrseña = i.Contrseña,
                Fk = i.FkRol,

            };

            return request;
        }

        public List<UsuarioResponse> ListConvert(List<Usuario> i)
        {
            List<UsuarioResponse> request = new List<UsuarioResponse>();

            foreach (Usuario item in i)
            {
                UsuarioResponse response = new UsuarioResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Usuario Inversor(UsuarioResponse i)
        {
            Usuario request = new Usuario()
            {
                Nombres = i.Nombres,
                Apellido_P = i.Apellido_P,
                Apellido_M = i.Apellido_M,
                Contrseña = i.Contrseña,
                FkRol = i.Fk,
                Estado = true

            };

            return request;
        }

        public List<Usuario> ListInversor(List<UsuarioResponse> i)
        {
            List<Usuario> request = new List<Usuario>();

            foreach (UsuarioResponse item in i)
            {
                UsuarioResponse response = new UsuarioResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }
    }
}
