namespace Banca.Bl
{
    public class UnitOfWork
    {
        public UnitOfWork(
            CodigoPostalBl codigoPostalBl,
            ClienteBl clienteBl
        ) { 
            CodigoPostal = codigoPostalBl;
            Cliente = clienteBl;
        }
        public ClienteBl Cliente { get; set; }
        public CodigoPostalBl CodigoPostal { get; set; }
    }
}
