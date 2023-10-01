using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoríaController : Controller
    {
        private readonly ICategoria _CategoriaServices;

        public CategoríaController(ICategoria categoriaServices)
        {
            _CategoriaServices = categoriaServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoria(string? Text, int fk)
        {
            return Ok(await _CategoriaServices.GetCategoria(Text,fk));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearCategorias(CategoriaResponse request)
        {
            return Ok(await _CategoriaServices.CrearCategorias(request));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaCategoria(CategoriaResponse i, int id)
        {
            return Ok(await _CategoriaServices.ActualizaCategoria(i,id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarCategoria( int id)
        {
            return Ok(await _CategoriaServices.EliminarCategoria(id));
        }




    }
}
