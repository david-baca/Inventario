using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using System.Collections.Generic;
using static inventarioAPI.Context.Aplication_DB_Context;
using static System.Net.Mime.MediaTypeNames;

namespace inventarioAPI.Services.Services
{
    public class RolServices : IRol
    {
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public RolServices(AplicationdbContext context)
        {
            _context = context;
        }


        public async Task<Response<List<RolResponse>>> GetRol(string Text)
        {
            try
            {
                Mensaje = "La lista de Roles";

                var response = await _context.Roles.Where(x => x.Estado == true).ToListAsync();

                if (Text != null)
                {
                    response = await _context.Roles.Where(x => x.Estado == true &&
                    (x.Nombre).Contains(Text)).ToListAsync();
                }

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Roles";
                    RolResponse x = new RolResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<RolResponse>>(respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<RolResponse>>(Mensaje, false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<RolResponse>> CrearRoles(RolResponse request)
        {
            try
            {

                _context.Roles.Add(request.Inversor(request));
                await _context.SaveChangesAsync();

                return new Response<RolResponse>("Elemento exitosamente guardado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<RolResponse>> ActualizaRol(RolResponse i, int id)
        {
            try
            {
                RolResponse x = new RolResponse();
                var resquest = _context.Roles.Where(x => x.Estado == true && x.PkRol == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<RolResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Nombre = i.Nombre;
                _context.Roles.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<RolResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<RolResponse>> EliminarRol(int id)
        {
            try
            {
                var Rol = _context.Articulos.Where(x => x.Responsable.FkRol == id).ToList();

                if (Rol.Count > 0)
                {
                    return new Response<RolResponse>("No se puede eliminar este elemento por que se encuentra asociado a un articulo", false);
                }

                RolResponse x = new RolResponse();
                var resquest = _context.Roles.Where(x => x.Estado == true && x.PkRol == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<RolResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Estado = false;
                _context.Roles.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<RolResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

    }
}
