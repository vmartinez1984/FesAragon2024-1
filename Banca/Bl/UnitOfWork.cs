namespace Banca.Bl
{
    public class UnitOfWork
    {
        public UnitOfWork(
            CodigoPostalBl codigoPostalBl,
            ClienteBl clienteBl,
            AhorroBl ahorroBl,
            TransaccionBl transaccionBl
        ) { 
            CodigoPostal = codigoPostalBl;
            Cliente = clienteBl;
            Ahorro = ahorroBl;
            Transaccion = transaccionBl;
        }
        public ClienteBl Cliente { get; set; }
        public CodigoPostalBl CodigoPostal { get; set; }
        public AhorroBl Ahorro { get; internal set; }
        public TransaccionBl Transaccion { get; internal set; }
    }
}
