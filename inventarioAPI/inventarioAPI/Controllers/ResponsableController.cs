using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsableController : Controller
    {
        private readonly IResponsable _ResponsableServices;

        public ResponsableController(IResponsable responsableServices)
        {
            _ResponsableServices = responsableServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetResponsable(string? Text, int fk)
        {
            return Ok(await _ResponsableServices.GetResponsable(Text, fk));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearResponsable(ResponsableResponse request)
        {
            return Ok(await _ResponsableServices.CrearResponsable(request));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaResponsables(ResponsableResponse i, int id)
        {
            return Ok(await _ResponsableServices.ActualizaResponsables(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarResponsables(int id)
        {
            return Ok(await _ResponsableServices.EliminarResponsables(id));
        }
    }
}
