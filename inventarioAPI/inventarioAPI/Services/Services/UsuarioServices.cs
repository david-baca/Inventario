using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using System.Collections.Generic;
using static inventarioAPI.Context.Aplication_DB_Context;

namespace inventarioAPI.Services.Services
{
    public class UsuarioServices : IUsuario
    {
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public UsuarioServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<UsuarioResponse>>> GetUsuario(string Usuario, string Contrasena)
        {
            try
            {
                Mensaje = "La lista de Usuarios";
                //var response = await _context.ListaRAs.Include(x => x.Articulo).Include(x => x.Responsable).ToListAsync();

                var response = await _context.Usuarios.Where(x => x.Estado == true && x.N_Usuario == Usuario && x.Contrseña == Contrasena).ToListAsync();


                if (response.Count > 0)
                {
                    Mensaje = "Usuario correcto";
                    UsuarioResponse x = new UsuarioResponse();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<UsuarioResponse>>(Mensaje, true);
                }
                else
                {
                    Mensaje = "Usuario o contraseña Incorrectos";
                    return new Response<List<UsuarioResponse>>(Mensaje, false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<UsuarioResponse>> CrearUsuarios(UsuarioResponse request)
        {
            try
            {

                _context.Usuarios.Add(request.Inversor(request));
                await _context.SaveChangesAsync();

                return new Response<UsuarioResponse>("Elemento exitosamente guardado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<UsuarioResponse>> ActualizaUsuario(UsuarioResponse i, int id)
        {
            try
            {
                UsuarioResponse x = new UsuarioResponse();
                var resquest = _context.Usuarios.Where(x => x.Estado == true && x.PkUsuario == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<UsuarioResponse>("No esxite este dato en la base de datos", false);
                }

                Historial hist = new Historial();
                hist.FkUsuario = i.IdUsuario;
                hist.FkAccion = 1;
                hist.Fecha = DateTime.Now;
                hist.Descripcion += "  Se < EDITO > el Usuario con Nombre: " + resquest.Nombres + " por " + i.Nombres;
                hist.Descripcion += "  Se < EDITO > el Usuario con Apellido paterno: " + resquest.Apellido_P + " por " + i.Apellido_P;
                hist.Descripcion += "  Se < EDITO > el Usuario con Apellido Materno: " + resquest.Apellido_M + " por " + i.Apellido_M;
                hist.Descripcion += "  Se < EDITO > el Usuario con Contraseña: " + resquest.Contrseña + " por " + i.Contrseña;


                resquest.Nombres = i.Nombres;
                resquest.Nombres = i.Nombres;
                resquest.Apellido_P = i.Apellido_P;
                resquest.Apellido_M = i.Apellido_M;
                resquest.Contrseña = i.Contrseña;

                _context.Historials.Update(hist);
                _context.Usuarios.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<UsuarioResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<UsuarioResponse>> EliminarUsuario(int id)
        {
            try
            {
                UsuarioResponse x = new UsuarioResponse();
                var resquest = _context.Usuarios.Where(x => x.Estado == true && x.PkUsuario == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<UsuarioResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Estado = false;
                _context.Usuarios.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<UsuarioResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
