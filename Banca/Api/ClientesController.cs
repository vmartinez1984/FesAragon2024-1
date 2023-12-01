using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Banca.Entities;
using Banca.Bl;

namespace Banca.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly BancaContext _context;
        private readonly UnitOfWork _unitOfWork;

        public ClientesController(BancaContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }

            return await _unitOfWork.Cliente.ObtenerTodosAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _unitOfWork.Cliente.ObtenerAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }


            try
            {
                await _unitOfWork.Cliente.ActualizarAsync(id, cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {            
            try
            {
                cliente.Id = await _unitOfWork.Cliente.AgregarAsync(cliente);
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _unitOfWork.Cliente.BorrarAsync(id);

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (_context.Cliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
