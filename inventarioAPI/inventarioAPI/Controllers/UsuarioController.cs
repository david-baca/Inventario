using Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _UsuarioServices;

        public UsuarioController(IUsuario Usuarioservices)
        {
            _UsuarioServices = Usuarioservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuario(string Usuario, string Contrasena)
        {
            return Ok(await _UsuarioServices.GetUsuario(Usuario, Contrasena));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearUsuarios(UsuarioResponse request)
        {
            return Ok(await _UsuarioServices.CrearUsuarios(request));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizaUsuario(UsuarioResponse i, int id)
        {
            return Ok(await _UsuarioServices.ActualizaUsuario(i, id));
        }

        [HttpPut("Borrar/{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            return Ok(await _UsuarioServices.EliminarUsuario(id));
        }
    }
}
