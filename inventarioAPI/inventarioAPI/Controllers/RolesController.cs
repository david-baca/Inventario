using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {
        private readonly IRol _RolServices;
        public RolesController(IRol RolServices)
        {
            _RolServices = RolServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetRol(string? Text)
        {
            return Ok(await _RolServices.GetRol(Text));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearRoles(RolResponse i)
        {
            return Ok(await _RolServices.CrearRoles(i));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaRol([FromBody] RolResponse i, int id)
        {
            return Ok(await _RolServices.ActualizaRol(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            return Ok(await _RolServices.EliminarRol(id));
        }

    }
}
