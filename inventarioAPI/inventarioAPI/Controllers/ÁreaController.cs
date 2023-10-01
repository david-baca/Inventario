using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class ÁreaController : Controller
    {

        private readonly IArea _AreaServices;

        public ÁreaController(IArea AreaServices)
        {
            _AreaServices = AreaServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetArea(string? Text)
        {
            return Ok(await _AreaServices.GetArea(Text));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearArea(AreaResponse i)

        {
            return Ok(await _AreaServices.CrearArea(i));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaArea([FromBody] AreaResponse i, int id)
        {
            return Ok(await _AreaServices.ActualizaArea(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarArea(int id)
        {
            return Ok(await _AreaServices.EliminarArea(id));
        }
    }
}
