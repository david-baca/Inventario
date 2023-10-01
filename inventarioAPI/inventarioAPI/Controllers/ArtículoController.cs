using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ArtículoController : Controller
    {

        private readonly IArticulo _ArticuloServices;

        public ArtículoController(IArticulo articuloservices)
        {
            _ArticuloServices = articuloservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticulo(string? Text, int fk)
        {
            return Ok(await _ArticuloServices.GetArticulo(Text, fk));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearArticulo(ArticuloResponse request)
        {
            return Ok(await _ArticuloServices.CrearArticulo(request));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaArticulo(ArticuloResponse i, int id)
        {
            return Ok(await _ArticuloServices.ActualizaArticulo(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarArticulo(int id)
        {
            return Ok(await _ArticuloServices.EliminarArticulo(id));
        }
    }
}
