using Banca.Bl;
using Banca.Repositorios.CodigosPostales;
using Microsoft.AspNetCore.Mvc;

namespace Banca.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigosPostalesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CodigosPostalesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{codigoPostal}")]
        public async Task<IActionResult> Obtener(string codigoPostal)
        {
            try
            {
                List<CodigoPostalDto> lista;

                lista = await _unitOfWork.CodigoPostal.Obtener(codigoPostal);
                //throw new Exception("Prueba");

                return Ok(lista);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Mensaje = "Valio pepino"});
            }
        }
    }
}
