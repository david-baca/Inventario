using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CategoriaResponse
    {
        public int IdUsuario { get; set; }
        public int Pk { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public int FkCatalogo { get; set; }

        public CatalogoResponse Catalogo { get; set; }


        public CategoriaResponse Conversor(Categoria i)
        {
            CatalogoResponse x = new CatalogoResponse();
            CategoriaResponse request = new CategoriaResponse()
            {
                Pk = i.PkCategoria,
                Marca = i.Marca,
                Modelo = i.Modelo,
                Descripcion = i.Descripcion,
                FkCatalogo = i.FkCatalogo,
                Catalogo = x.Conversor(i.Catalogo)
            };

            return request;
        }

        public List<CategoriaResponse> ListConvert(List<Categoria> i)
        {
            List<CategoriaResponse> request = new List<CategoriaResponse>();

            foreach (Categoria item in i)
            {
                CategoriaResponse response = new CategoriaResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Categoria Inversor(CategoriaResponse i)
        {
            Categoria request = new Categoria()
            {
                Marca = i.Marca,
                Modelo = i.Modelo,
                Descripcion = i.Descripcion,
                FkCatalogo = i.FkCatalogo,
                Estado = true
                
            };

            return request;
        }

        public List<Categoria> ListInversor(List<CategoriaResponse> i)
        {
            List<Categoria> request = new List<Categoria>();

            foreach (CategoriaResponse item in i)
            {
                CategoriaResponse response = new CategoriaResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }

    }


}
