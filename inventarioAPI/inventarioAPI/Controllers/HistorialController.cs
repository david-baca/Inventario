using inventarioAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace inventarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistorialController : Controller
    {
        private readonly IHistorial _HistorialService;

        public HistorialController(IHistorial historialService)
        {
            _HistorialService = historialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistorial(string? Text)
        {
            return Ok(await _HistorialService.GetHistorial(Text));
        }
    }
}
