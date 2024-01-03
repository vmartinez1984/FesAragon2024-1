namespace Banca.Dtos
{
    public class Paginador
    {
        public int Pagina { get; set; } = 1;

        public int NumeroDeRegistrosPorPagina { get; set; } = 10;

        public string Busqueda { get; set; }

        public int TotalDeRegistros { get; set; }

        public int TotalDeRegistrosFiltrados { get; set; }

        public int CountPage
        {
            get
            {
                return (int)Math.Ceiling((double)TotalDeRegistros / NumeroDeRegistrosPorPagina);
            }
        }
    }
}
