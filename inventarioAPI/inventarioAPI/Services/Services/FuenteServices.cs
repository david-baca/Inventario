using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using System.Collections.Generic;
using static inventarioAPI.Context.Aplication_DB_Context;
using Microsoft.Extensions.Hosting;

namespace inventarioAPI.Services.Services
{
    public class FuenteServices : IFuente
    {
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public FuenteServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<FuenteResponse>>> GetFuente(string Text)
        {
            try
            {
                Mensaje = "La lista de Fuentes";
                var response = await _context.Fuentes.Where(x => x.Estado == true).ToListAsync();

                if (Text != null)
                {
                    response = await _context.Fuentes.Where(x => x.Estado == true &&
                    (x.Nombre).Contains(Text)).ToListAsync();
                }

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Fuentes";
                    FuenteResponse x = new FuenteResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<FuenteResponse>>(respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<FuenteResponse>>(Mensaje, false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<FuenteResponse>> CrearFuente(FuenteResponse request)
        {
            try
            {

                _context.Fuentes.Add(request.Inversor(request));
                await _context.SaveChangesAsync();

                return new Response<FuenteResponse>("Elemento exitosamente guardado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<FuenteResponse>> ActualizaFuente(FuenteResponse i, int id)
        {
            try
            {
                FuenteResponse x = new FuenteResponse();
                var resquest = _context.Fuentes.Where(x => x.Estado == true && x.PkFuente == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<FuenteResponse>("No esxite este dato en la base de datos", false);
                }

                Historial hist = new Historial();
                hist.FkUsuario = i.IdUsuario;
                hist.FkAccion = 1;
                hist.Fecha = DateTime.Now;
                hist.Descripcion += "se < EDITO > la Fuente con Nombre: " + resquest.Nombre + " por " + i.Nombre;


                resquest.Nombre = i.Nombre;

                _context.Historials.Update(hist);
                _context.Fuentes.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<FuenteResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<FuenteResponse>> EliminarFuente(int id)
        {
            try
            {
                var Fuente = _context.Articulos.Where(x => x.FkFuente == id).ToList();

                if (Fuente.Count > 0)
                {
                    return new Response<FuenteResponse>("No se puede eliminar este elemento por que se encuentra asociado a un articulo", false);
                }

                FuenteResponse x = new FuenteResponse();
                var resquest = _context.Fuentes.Where(x => x.Estado == true && x.PkFuente == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<FuenteResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Estado = false;
                _context.Fuentes.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<FuenteResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
