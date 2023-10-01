using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuenteController : Controller
    {
        private readonly IFuente _FuenteServices;

        public FuenteController(IFuente fuenteservices)
        {
            _FuenteServices = fuenteservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetFuente(string? Text)
        {
            return Ok(await _FuenteServices.GetFuente(Text));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearFuente(FuenteResponse i)
        {
            return Ok(await _FuenteServices.CrearFuente(i));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaFuente([FromBody] FuenteResponse i, int id)
        {
            return Ok(await _FuenteServices.ActualizaFuente(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarFuente(int id)
        {
            return Ok(await _FuenteServices.EliminarFuente(id));
        }
    }
}
