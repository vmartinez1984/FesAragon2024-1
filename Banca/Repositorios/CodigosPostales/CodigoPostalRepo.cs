using Newtonsoft.Json;

namespace Banca.Repositorios.CodigosPostales
{
    public class CodigoPostalRepo
    {
        private readonly string _url;

        public CodigoPostalRepo(IConfiguration configuration)
        {
            _url = configuration.GetValue<string>("ApiCodigosPostales") + "CodigosPostales/";

        }

        public async Task<List<CodigoPostalDto>> Obtener(string codigoPostal)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            HttpRequestMessage request;
            List<CodigoPostalDto> lista;

            request = new HttpRequestMessage(HttpMethod.Get, _url+ codigoPostal);
            response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                lista = JsonConvert.DeserializeObject<List<CodigoPostalDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var data = await response.Content.ReadAsStringAsync();
                lista = new List<CodigoPostalDto>();
            }

            return lista;
        }
    }
}
