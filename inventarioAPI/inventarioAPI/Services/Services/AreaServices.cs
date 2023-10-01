using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using System.Collections.Generic;
using static inventarioAPI.Context.Aplication_DB_Context;

namespace inventarioAPI.Services.Services
{
    public class AreaServices : IArea
    {
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public AreaServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<AreaResponse>>> GetArea(string Text)
        {
            try
            {
                Mensaje = "La lista de Areas";

                var response = await _context.Areas.Where(x => x.Estado == true).ToListAsync();

                if (Text != null)
                {
                    response = await _context.Areas.Where(x => x.Estado == true &&
                    (x.Nombre).Contains(Text)).ToListAsync();
                }


                if (Text == null) { response = await _context.Areas.Where(x => x.Estado == true).ToListAsync(); }

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Areas";
                    AreaResponse x = new AreaResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<AreaResponse>>(respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<AreaResponse>>(Mensaje, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }


        public async Task<Response<AreaResponse>> CrearArea(AreaResponse request)
        {
            try
            {

                _context.Areas.Add(request.Inversor(request));
                await _context.SaveChangesAsync();

                return new Response<AreaResponse>("Elemento exitosamente guardado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<AreaResponse>> ActualizaArea(AreaResponse i, int id)
        {
            try
            {
                AreaResponse x = new AreaResponse();
                var resquest = _context.Areas.Where(x => x.Estado == true && x.PkArea == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<AreaResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Nombre = i.Nombre;
                _context.Areas.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<AreaResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<AreaResponse>> EliminarArea(int id)
        {
            try
            {
                AreaResponse x = new AreaResponse();
                var resquest = _context.Areas.Where(x => x.Estado == true && x.PkArea == id).FirstOrDefault();
                var Articulos = _context.Articulos.Where(x => x.FkArea == id).ToList();

                if(Articulos.Count > 0)
                {
                    return new Response<AreaResponse>("No se puede eliminar este elemento por que se encuentra asociado a un articulo", false);
                }

                if (resquest == null)
                {
                    return new Response<AreaResponse>("No esxite este dato en la base de datos", true);
                }

                resquest.Estado = false;
                _context.Areas.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<AreaResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }


    }
}


