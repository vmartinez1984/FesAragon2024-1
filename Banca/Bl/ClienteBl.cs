using Banca.Entities;
using Microsoft.EntityFrameworkCore;
using Banca.Dtos;

namespace Banca.Bl
{
    public class ClienteBl
    {
        private readonly BancaContext _context;

        public ClienteBl(BancaContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            List<Cliente> entities;

            entities = await _context.Cliente.Where(x => x.EstaActivo).ToListAsync();

            return entities;
        }

        internal async Task ActualizarAsync(int id, Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        internal async Task<int> AgregarAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente.Id;
        }

        internal async Task BorrarAsync(int id)
        {
            Cliente cliente;

            cliente = await ObtenerAsync(id);
            cliente.EstaActivo = false;
            _context.Cliente.Update(cliente);

            await _context.SaveChangesAsync();
        }

        internal async Task<Cliente> ObtenerAsync(int id)
        {
            Cliente cliente;

            cliente = await _context.Cliente
                .Include(x => x.Ahorros)
                .Where(x => x.EstaActivo).FirstOrDefaultAsync();

            return cliente;
        }

        internal async Task<List<Cliente>> ObtenerAsync(Paginador paginador)
        {
            List<Cliente> lista;

            lista = new List<Cliente>();
            if (!string.IsNullOrEmpty(paginador.Busqueda))
            {
                lista = await _context.Cliente
                    .Where(x => x.Nombres.Contains(paginador.Busqueda) || x.PrimerApellido.Contains(paginador.Busqueda) || x.SegundoApellido.Contains(paginador.Busqueda) || x.Id.ToString().Contains(paginador.Busqueda))                    
                    .OrderBy(x => x.Id)
                    .Skip((paginador.Pagina - 1) * paginador.NumeroDeRegistrosPorPagina)
                    .Take(paginador.NumeroDeRegistrosPorPagina)
                    .ToListAsync();
                paginador.TotalDeRegistrosFiltrados = await _context.Cliente
                 .Where(x => x.Nombres.Contains(paginador.Busqueda) || x.PrimerApellido.Contains(paginador.Busqueda) || x.SegundoApellido.Contains(paginador.Busqueda) || x.Id.ToString().Contains(paginador.Busqueda))                 
                 .OrderBy(x => x.Id)
                 .Skip((paginador.Pagina - 1) * paginador.NumeroDeRegistrosPorPagina)
                 .Take(paginador.NumeroDeRegistrosPorPagina)
                 .CountAsync();
            }
            else
            {
                lista = await _context.Cliente                    
                    .OrderBy(x => x.Id)
                    .Skip((paginador.Pagina - 1) * paginador.NumeroDeRegistrosPorPagina)
                    .Take(paginador.NumeroDeRegistrosPorPagina)
                    .ToListAsync();
                paginador.TotalDeRegistrosFiltrados = await _context.Cliente                 
                 .OrderBy(x => x.Id)
                 .Skip((paginador.Pagina - 1) * paginador.NumeroDeRegistrosPorPagina)
                 .Take(paginador.NumeroDeRegistrosPorPagina)
                 .CountAsync();
            }
            paginador.TotalDeRegistros = await _context.Cliente.CountAsync();

            return lista;
        }
    }
}