using Domain.Dto;
using Domain.Entity;
using inventarioAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;
using static inventarioAPI.Context.Aplication_DB_Context;

namespace inventarioAPI.Services.Services
{
    public class HistorialServices : IHistorial
    {
        private readonly AplicationdbContext _context;
        public HistorialServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<HistorialResponse>>> GetHistorial(string text)
        {
            try
            {

                List<Historial> response = new List<Historial>();


                response = await _context.Historials.
                Include(x => x.Accion).
                Include(x => x.Usuario).ToListAsync();

                if (text != null)
                {
                    response = await _context.Historials.
                    Where(x => x.Descripcion.Contains(text) || x.Accion.Nombre.Contains(text)).
                    Include(x => x.Accion).
                    Include(x => x.Usuario).ToListAsync();
                }


                if (response.Count > 0)
                {

                    HistorialResponse x = new HistorialResponse();
                    var respuesta = x.ListConvert(response);
                    string Mensaje = "Se encontro exitosamente";
                    return new Response<List<HistorialResponse>>(respuesta, Mensaje);
                }
                else
                {
                    string Mensaje = "No se encontro movimientos en el historial";
                    return new Response<List<HistorialResponse>>(Mensaje, true);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

    }
}

