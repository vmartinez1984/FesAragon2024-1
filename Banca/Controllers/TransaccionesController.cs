using Banca.Bl;
using Banca.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Banca.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public TransaccionesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("ahorros/{ahorroId}/depositar")]
        public async Task<IActionResult> Depositar(int ahorroId)
        {
            Ahorro ahorro;

            ahorro = await _unitOfWork.Ahorro.ObtenerAsync(ahorroId);
            ViewBag.Ahorro = ahorro;

            return View();
        }

        [HttpPost("ahorros/{ahorroId}/depositar")]
        public async Task<IActionResult> Depositar(int ahorroId, Transaccion transaccion)
        {
            int id;
            Ahorro ahorro;

            transaccion.FechaDeRegistro = DateTime.Now;
            id = await _unitOfWork.Transaccion.DepositarAsync(ahorroId, transaccion);
            ahorro = await _unitOfWork.Ahorro.ObtenerAsync(ahorroId);

            return RedirectToAction("Details", "Clientes", new { id = ahorro.ClienteId });
        }

        [HttpGet("ahorros/{ahorroId}/retirar")]
        public async Task<IActionResult> Retirar(int ahorroId)
        {
            Ahorro ahorro;

            ahorro = await _unitOfWork.Ahorro.ObtenerAsync(ahorroId);
            ViewBag.Ahorro = ahorro;

            return View();
        }

        [HttpPost("ahorros/{ahorroId}/retirar")]
        public async Task<IActionResult> Retirar(int ahorroId, Transaccion transaccion)
        {
            Ahorro ahorro;
            try
            {
                int id;

                transaccion.FechaDeRegistro = DateTime.Now;
                ahorro = await _unitOfWork.Ahorro.ObtenerAsync(ahorroId);
                ViewBag.Ahorro = ahorro;
                id = await _unitOfWork.Transaccion.RetirarAsync(ahorroId, transaccion);

                return RedirectToAction("Details", "Clientes", new { id = ahorro.ClienteId });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }


        [HttpGet("ahorros/{ahorroId}/detalles")]
        public async Task<IActionResult> Detalles(int ahorroId)
        {
            List<Transaccion> lista;

            lista = await _unitOfWork.Transaccion.ObtenerTodosAsync(ahorroId);

            return View(lista);
        }
    }
}
