using Domain.Entity;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ArticuloResponse
    {
        public int Pk { get; set; }

        public string FEQADD { get; set; }

        public string FEQASIC { get; set; }

        public int Costo { get; set; }

        public string Polisa { get; set; }

        public string Factura { get; set; }

        public string Token { get; set; }

        public int fkResonsable { get; set; }

        //Se deben eliminar 
        public int FkCategoria { get; set; }

        public int FkProvedor { get; set; }

        public int FkFuente { get; set; }

        public int FkArea { get; set; }

        public bool Estado { get; set; }

        //todos estos

        public ArticuloResponse Conversor(Articulo i)
        {
            
            ArticuloResponse request = new ArticuloResponse();
            request.Pk = i.PkArticulo;
            request.FEQADD = i.FEQADD.Date.ToString("yyyy-MM-dd");
            request.FEQASIC = i.FEQ_ASC.Date.ToString("yyyy-MM-dd");
            request.Polisa = i.Polisa;
            request.Costo = i.Costo;
            request.Factura = i.Factura;
            request.Token = i.Token;
            request.Estado = i.Estado_Articulo;
            request.FkCategoria = i.FkCategoria;
            request.FkProvedor = i.FkProvedor;
            request.FkFuente = i.FkFuente;
            request.FkArea = i.FkArea;
            request.fkResonsable = i.FkResponsable;
            return request;
        }

        public List<ArticuloResponse> ListConvert(List<Articulo> i)
        {
            List<ArticuloResponse> request = new List<ArticuloResponse>();

            foreach (Articulo item in i)
            {
                ArticuloResponse response = new ArticuloResponse();
                request.Add(response.Conversor(item));
            }

            return request;
        }

        public Articulo Inversor(ArticuloResponse i)
        {
            Articulo request = new Articulo()
            {
                PkArticulo = i.Pk,
                FEQADD = DateTime.Parse(i.FEQADD),
                FEQ_ASC = DateTime.Parse(i.FEQASIC),
                Polisa = i.Polisa,
                Factura = i.Factura,
                Token = i.Token,
                Costo = i.Costo,
                FkResponsable = i.fkResonsable,
                FkCategoria = i.FkCategoria,
                FkProvedor = i.FkProvedor,
                FkFuente = i.FkFuente,
                FkArea = i.FkArea,
                Estado_Articulo = true,
                Estado = true
            };

            return request;
        }

        public List<Articulo> ListInversor(List<ArticuloResponse> i)
        {
            List<Articulo> request = new List<Articulo>();

            foreach (ArticuloResponse item in i)
            {
                ArticuloResponse response = new ArticuloResponse();
                request.Add(response.Inversor(item));
            }

            return request;
        }

    }

    public class ArticuloRequest
    {
        public ArticuloResponse Articulo { get; set; }

        public CategoriaResponse Categoria { get; set; }

        public CatalogoResponse Catalogo { get; set; }

        public ProvedorResponse Provedor { get; set; }

        public FuenteResponse Fuente { get; set; }

        public AreaResponse Area { get; set; }

        public RolResponse Rol { get; set; }

        public ResponsableResponse Responsable { get; set; }

        public ArticuloRequest Conversor(Articulo i)
        {

            ArticuloRequest request = new ArticuloRequest();
            request.Articulo = new ArticuloResponse().Conversor(i);
            request.Categoria = new CategoriaResponse().Conversor(i.Categoria);
            request.Catalogo = new CatalogoResponse().Conversor(i.Categoria.Catalogo);
            request.Provedor = new ProvedorResponse().Conversor(i.Provedor);
            request.Fuente = new FuenteResponse().Conversor(i.Fuente);
            request.Area = new AreaResponse().Conversor(i.Area);
            request.Responsable = new ResponsableResponse().Conversor(i.Responsable);
            request.Rol = new RolResponse().Conversor(i.Responsable.Rol);

            return request;
        }

        public List<ArticuloRequest> ListConvert(List<Articulo> i)
        {
            List<ArticuloRequest> request = new List<ArticuloRequest>();

            foreach (Articulo item in i)
            {
                ArticuloRequest response = new ArticuloRequest();
                request.Add(response.Conversor(item));
            }

            return request;
        }
    }
}

    


