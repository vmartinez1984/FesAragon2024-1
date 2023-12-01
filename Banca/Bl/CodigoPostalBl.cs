using Banca.Repositorios.CodigosPostales;

namespace Banca.Bl
{
    public class CodigoPostalBl
    {
        private readonly CodigoPostalRepo _codigoPostalRepo;

        public CodigoPostalBl( CodigoPostalRepo codigoPostalRepo)
        {
            _codigoPostalRepo = codigoPostalRepo;
        }

        public async Task<List<CodigoPostalDto>> Obtener(string codigoPostal)
        {
            List<CodigoPostalDto> lista;

            lista = await _codigoPostalRepo.Obtener(codigoPostal);

            return lista;
        }
    }

}