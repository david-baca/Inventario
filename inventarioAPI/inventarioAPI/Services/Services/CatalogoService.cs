using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using System.Collections.Generic;
using static inventarioAPI.Context.Aplication_DB_Context;

namespace inventarioAPI.Services.Services
{
    public class CatalogoService : ICatalogo
    {
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public CatalogoService(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<CatalogoResponse>>> GetCatalogo(string Text)
        {
            try
            {
                Mensaje = "La lista de Catalogos";

                var response = await _context.Catalogos.Where(x => x.Estado == true).ToListAsync();

                if (Text != null)
                {
                    response = await _context.Catalogos.Where(x => x.Estado == true &&
                    (x.Nombre).Contains(Text)).ToListAsync();
                }

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Catalogos";
                    CatalogoResponse x = new CatalogoResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<CatalogoResponse>> (respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<CatalogoResponse>> (Mensaje, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<CatalogoResponse>> CrearCatalogos(CatalogoResponse request)
        {
            try
            {
                var x = request.Inversor(request);
                await _context.Catalogos.AddAsync(x);
                await _context.SaveChangesAsync();

                return new Response<CatalogoResponse>("Elemento exitosamente guardado",true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<CatalogoResponse>> ActualizaCatalogo(CatalogoResponse i, int id)
        {
            try
            {
                CatalogoResponse x = new CatalogoResponse();
                var resquest = _context.Catalogos.Where(x => x.Estado == true && x.PkCatalogo == id).FirstOrDefault();

                if (resquest == null)
                {
                   return new Response<CatalogoResponse> ("No esxite este dato en la base de datos", true);
                }

               


                Historial hist = new Historial();
                hist.FkUsuario = i.IdUsuario;
                hist.FkAccion = 1;
                hist.Fecha = DateTime.Now;
                hist.Descripcion += "se < EDITO > el Catalogo con Nombre: " + resquest.Nombre + " por " + i.Nombre;

                resquest.Nombre = i.Nombre;

                _context.Historials.Update(hist);
                _context.Catalogos.Update(resquest);
                await _context.SaveChangesAsync();;

                return new Response<CatalogoResponse>("Elemento exitosamente editado",true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<CatalogoResponse>> EliminarCatalogo (int id)
        {
            try
            {
                var Catalogo = _context.Articulos.Where(x => x.Categoria.Catalogo.PkCatalogo == id).ToList();

                if (Catalogo.Count > 0)
                {
                    return new Response<CatalogoResponse>("No se puede eliminar este elemento por que se encuentra asociado a un articulo", false);
                }

                CatalogoResponse x = new CatalogoResponse();
                var resquest = _context.Catalogos.Where(x => x.Estado == true && x.PkCatalogo == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<CatalogoResponse>("No esxite este dato en la base de datos",false);
                }

                resquest.Estado = false;
                _context.Catalogos.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<CatalogoResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

    }
}
