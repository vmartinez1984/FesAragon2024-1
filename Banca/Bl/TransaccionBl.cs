using Banca.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banca.Bl
{
    public class TransaccionBl
    {
        private readonly BancaContext _context;

        public TransaccionBl(BancaContext context)
        {
            _context = context;
        }

        internal async Task<int> DepositarAsync(int depositoId, Transaccion transaccion)
        {
            decimal retiros;
            decimal depositos;
            Ahorro ahorro;

            transaccion.Tipo = Tipo.Deposito;
            await _context.Transaccion.AddAsync(transaccion);
            await _context.SaveChangesAsync();
            retiros = await _context.Transaccion.Where(x=> x.Tipo == Tipo.Retiro).SumAsync(x => x.Cantidad);
            depositos = await _context.Transaccion.Where(x => x.Tipo == Tipo.Deposito).SumAsync(x => x.Cantidad);
            ahorro = await _context.Ahorro.FindAsync(depositoId);
            ahorro.Balance = depositos - retiros;
            _context.Ahorro.Update(ahorro);
            await _context.SaveChangesAsync();

            return transaccion.Id;
        }

        internal async Task<List<Transaccion>> ObtenerTodosAsync(int ahorroId)
        {
            List<Transaccion> lista;

            lista = await _context.Transaccion.Where(x=> x.AhorroId == ahorroId).ToListAsync();

            return lista;
        }

        internal async Task<int> RetirarAsync(int ahorroId, Transaccion transaccion)
        {
            decimal retiros;
            decimal depositos;
            Ahorro ahorro;

            transaccion.Tipo = Tipo.Retiro;
            ahorro = await _context.Ahorro.FindAsync(ahorroId);
            if (ahorro.Balance <= transaccion.Cantidad)
                throw new Exception("No cuenta con saldo suficiente");
            await _context.Transaccion.AddAsync(transaccion);
            await _context.SaveChangesAsync();
            retiros = await _context.Transaccion.Where(x => x.Tipo == Tipo.Retiro).SumAsync(x => x.Cantidad);
            depositos = await _context.Transaccion.Where(x => x.Tipo == Tipo.Deposito).SumAsync(x => x.Cantidad);
            ahorro.Balance = depositos - retiros;
            _context.Ahorro.Update(ahorro);
            await _context.SaveChangesAsync();

            return transaccion.Id;
        }

    }
}
