using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CatalogosController : Controller
    {
        private readonly ICatalogo _CatalogoServices;

        public CatalogosController(ICatalogo catalogoServices)
        {
            _CatalogoServices = catalogoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatalogo(string? Text)
        {
            return Ok(await _CatalogoServices.GetCatalogo(Text));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearCatalogos(CatalogoResponse request)
        {
            return Ok(await _CatalogoServices.CrearCatalogos(request));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaCatalogo([FromBody] CatalogoResponse i, int id)
        {
            return Ok(await _CatalogoServices.ActualizaCatalogo(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarCatalogo(int id)
        {
            return Ok(await _CatalogoServices.EliminarCatalogo(id));
        }
    }
}
