using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using System.Collections.Generic;
using static inventarioAPI.Context.Aplication_DB_Context;

namespace inventarioAPI.Services.Services
{
    public class ProvedorServices : IProvedor
    {
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public ProvedorServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<ProvedorResponse>>> GetProvedor(string Text)
        {
            try
            {
                Mensaje = "La lista de Fuentes";

                var response = await _context.Provedores.Where(x => x.Estado == true).ToListAsync();

                if (Text != null)
                {
                    response = await _context.Provedores.Where(x => x.Estado == true &&
                    (x.Nombre).Contains(Text)).ToListAsync();
                }

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Fuentes";
                    ProvedorResponse x = new ProvedorResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<ProvedorResponse>>(respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<ProvedorResponse>>(Mensaje, false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<ProvedorResponse>> CrearProvedor(ProvedorResponse request)
        {
            try
            {

                _context.Provedores.Add(request.Inversor(request));
                await _context.SaveChangesAsync();

                return new Response<ProvedorResponse>("Elemento exitosamente guardado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<ProvedorResponse>> ActualizaProvedor(ProvedorResponse i, int id)
        {
            try
            {
                ProvedorResponse x = new ProvedorResponse();
                var resquest = _context.Provedores.Where(x => x.Estado == true && x.PkProvedor == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<ProvedorResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Nombre = i.Nombre;
                _context.Provedores.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<ProvedorResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<ProvedorResponse>> EliminarProvedor(int id)
        {
            try
            {
                var Provedor = _context.Articulos.Where(x => x.FkProvedor == id).ToList();

                if (Provedor.Count > 0)
                {
                    return new Response<ProvedorResponse>("No se puede eliminar este elemento por que se encuentra asociado a un articulo", false) ;
                }

                ProvedorResponse x = new ProvedorResponse();
                var resquest = _context.Provedores.Where(x => x.Estado == true && x.PkProvedor == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<ProvedorResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Estado = false;
                _context.Provedores.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<ProvedorResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
