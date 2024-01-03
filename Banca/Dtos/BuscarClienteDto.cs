using System.ComponentModel.DataAnnotations;

namespace Banca.Dtos
{
    public class BuscarClienteDto
    {
        [Key]
        public int Id { get; set; }
        public string Busqueda { get; set; }
    }
}
