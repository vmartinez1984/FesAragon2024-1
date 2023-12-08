using Banca.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banca.Bl
{
    public class AhorroBl
    {
        private readonly BancaContext _context;

        public AhorroBl(BancaContext context)
        {
            _context = context;
        }


        internal async Task<Ahorro> ObtenerAsync(int depositoId)
        {
            Ahorro ahorro;

            ahorro = await _context.Ahorro.Where(x => x.Id == depositoId).FirstOrDefaultAsync();

            return ahorro;
        }
    }
}
