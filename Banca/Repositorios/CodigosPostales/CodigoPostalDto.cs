using Newtonsoft.Json;

namespace Banca.Repositorios.CodigosPostales
{
    public class CodigoPostalDto
    {
        [JsonProperty("codigoPostal")]
        public string CodigoPostal { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("estadoId")]
        public string EstadoId { get; set; }

        [JsonProperty("alcaldia")]
        public string Alcaldia { get; set; }

        [JsonProperty("tipoDeAsentamiento")]
        public string TipoDeAsentamiento { get; set; }

        [JsonProperty("asentamiento")]
        public string Asentamiento { get; set; }
    }
}
