using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;

namespace inventarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvedorController : Controller
    {
        private readonly IProvedor _ProvedorServices;

        public ProvedorController(IProvedor catalogoServices)
        {
            _ProvedorServices = catalogoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetProvedor(string? Text)
        {
            return Ok(await _ProvedorServices.GetProvedor(Text));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearProvedor(ProvedorResponse i)
        {
            return Ok(await _ProvedorServices.CrearProvedor(i));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaProvedor([FromBody] ProvedorResponse i , int id)
        {
            return Ok(await _ProvedorServices.ActualizaProvedor(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarProvedor(int id)
        {
            return Ok(await _ProvedorServices.EliminarProvedor(id));
        }
    }
}
