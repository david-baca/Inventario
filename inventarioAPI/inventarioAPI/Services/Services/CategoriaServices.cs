using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using static inventarioAPI.Context.Aplication_DB_Context;

namespace inventarioAPI.Services.Services
{
    public class CategoriaServices : ICategoria
    {

        private readonly AplicationdbContext _context;
        public string Mensaje;
        public CategoriaServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<CategoriaResponse>>> GetCategoria(string Text, int fk)
        {
            try
            {
                Mensaje = "La lista de Categorias";
                //var response = await _context.ListaRAs.Include(x => x.Articulo).Include(x => x.Responsable).ToListAsync();

                var response = await _context.Categorias.Where(x => x.Estado == true).Include(x=>x.Catalogo).ToListAsync();

                if (Text != null)
                {
                    response = await _context.Categorias.Where(x => x.Estado == true &&
                    (x.Descripcion).Contains(Text)).Include(x => x.Catalogo).ToListAsync();
                }

                if (fk!=0)
                {
                    response = await _context.Categorias.Where(x => x.Estado == true && x.FkCatalogo == fk).Include(x => x.Catalogo)
                        .ToListAsync();
                }

                if (Text != null && fk!=0)
                {
                    response = await _context.Categorias.Where(x => x.Estado == true &&
                    (x.Descripcion).Contains(Text) && x.FkCatalogo == fk).Include(x => x.Catalogo).ToListAsync();
                }





                if (response.Count > 0)
                {
                    Mensaje = "La lista de Categorias";
                    CategoriaResponse x = new CategoriaResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<CategoriaResponse>>(respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<CategoriaResponse>>(Mensaje, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<CategoriaResponse>> CrearCategorias(CategoriaResponse request)
        {
            try
            {

                _context.Categorias.Add(request.Inversor(request));
                await _context.SaveChangesAsync();

                return new Response<CategoriaResponse>("Elemento exitosamente guardado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<CategoriaResponse>> ActualizaCategoria(CategoriaResponse i, int id)
        {
            try
            {
                CategoriaResponse x = new CategoriaResponse();
                var resquest = _context.Categorias.Where(x => x.Estado == true && x.PkCategoria == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<CategoriaResponse>("No existe este dato en la base de datos", false);
                }
                resquest.Marca = i.Marca;
                resquest.Modelo = i.Modelo;
                resquest.Descripcion = i.Descripcion;


                _context.Categorias.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<CategoriaResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<CategoriaResponse>> EliminarCategoria(int id)
        {
            try
            {
                var Categoria = _context.Articulos.Where(x => x.Categoria.PkCategoria == id).ToList();

                if (Categoria.Count > 0)
                {
                    return new Response<CategoriaResponse>("No se puede eliminar este elemento por que se encuentra asociado a un articulo", false);
                }

                CategoriaResponse x = new CategoriaResponse();
                var resquest = _context.Categorias.Where(x => x.Estado == true && x.PkCategoria == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<CategoriaResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Estado = false;
                _context.Categorias.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<CategoriaResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }


    }

}
