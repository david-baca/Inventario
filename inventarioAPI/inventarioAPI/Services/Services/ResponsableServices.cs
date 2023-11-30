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
    public class ResponsableServices : IResponsable
    {
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public ResponsableServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<ResponsableResponse>>> GetResponsable(string Text, int fk)
        {
            try
            {
                Mensaje = "La lista de Categorias";
                //var response = await _context.ListaRAs.Include(x => x.Articulo).Include(x => x.Responsable).ToListAsync();
                

                var response = await _context.Responsables.Where(x => x.Estado == true).Include(x=>x.Rol).ToListAsync();

                if (Text != null) { response = await _context.Responsables.Where(x => x.Estado == true && 
                    (x.Nombre+x.ApellidoP+x.ApellidoM).Contains(Text) ).Include(x => x.Rol).ToListAsync(); }

                if (fk!=0)
                {
                    response = await _context.Responsables.Where(x => x.Estado == true && x.FkRol == fk).Include(x => x.Rol).ToListAsync();
                }

                if (Text != null && fk!=0)
                {
                    response = await _context.Responsables.Where(x => x.Estado == true &&
                    (x.Nombre+x.ApellidoP+x.ApellidoM).Contains(Text) && x.FkRol == fk).Include(x => x.Rol).ToListAsync();
                }


                if (response.Count > 0)
                {
                    Mensaje = "La lista de Responsables";
                    ResponsableResponse x = new ResponsableResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<ResponsableResponse>>(respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<ResponsableResponse>>(Mensaje, false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<ResponsableResponse>> CrearResponsable(ResponsableResponse request)
        {
            try
            {

                _context.Responsables.Add(request.Inversor(request));
                await _context.SaveChangesAsync();

                return new Response<ResponsableResponse>("Elemento exitosamente guardado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<ResponsableResponse>> ActualizaResponsables(ResponsableResponse i, int id)
        {
            try
            {
                ResponsableResponse x = new ResponsableResponse();
                var resquest = _context.Responsables.Where(x => x.Estado == true && x.PkResponsable == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<ResponsableResponse>("No esxite este dato en la base de datos", false);
                }
                resquest.Nombre = i.Nombre;
                resquest.ApellidoP = i.ApellidoP;
                resquest.ApellidoM = i.ApellidoM;
             


                _context.Responsables.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<ResponsableResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<ResponsableResponse>> EliminarResponsables(int id)
        {
            try
            {
                var Responsable = _context.Articulos.Where(x => x.FkResponsable == id).ToList();

                if (Responsable.Count > 0)
                {
                    return new Response<ResponsableResponse>("No se puede eliminar este elemento por que se encuentra asociado a un articulo", false);
                }

                ResponsableResponse x = new ResponsableResponse();
                var resquest = _context.Responsables.Where(x => x.Estado == true && x.PkResponsable == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<ResponsableResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Estado = false;
                _context.Responsables.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<ResponsableResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

    }
}
